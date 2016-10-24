using PasteBookBusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookModel;

namespace PasteBook.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home

        Post post = new Post();
        Comment comment = new Comment();
        Friend friend = new Friend();
        Like like = new Like();
        User user = new User();
        Notification notif = new Notification();


        [HttpGet]
        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = this.user.GetUser(user);
                return View(result);
            }
            else
            {
                return RedirectToAction("Index","PasteBook");
            }
        }
        public JsonResult GetUserID(string emailAddress)
        {
            var result = user.GetUserID(emailAddress);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddOrDeleteLike(int postID, int ID)
        {
            string status = "";
            var result = like.AddOrDeleteLike(ID, postID, out status);
            return Json(new { result = result, status = status }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPost(int userId, string post, int ProfileOwnerID)
        {
            var result = this.post.AddPost(userId, post, ProfileOwnerID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Newsfeed(int id)
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = post.GetListOfPostNewsFeed(user);
                return PartialView("PartialViewNewsFeed", result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }

        }
        public ActionResult TimelineFeed(int id)
        {
         if (Session["User"] != null)
            {
                
                var result = post.GetListOfPostTimeline(id);
                return PartialView("PartialViewNewsFeed", result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        public ActionResult UserProfile()
        {

            return View();
        }

        public ActionResult Timeline(int id)
        {
            if (Session["User"] != null)
            {
              
                var result = this.user.GetUser(id);

                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        public ActionResult AddFriendView(int id)
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                ViewBag.isFriend = friend.IsFriend(user, id);
                ViewBag.id = id;
                return PartialView("PartialViewFriendRequest",new { id = id });
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        public ActionResult NotificationView()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = notif.GetListOfNotifications(user);
                return PartialView("PartialViewNotification",result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }

        public ActionResult Friends()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = friend.GetUserFriends(user);
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        public ActionResult EditProfile()
        {
            return View();
        }
       [HttpPost]
        public ActionResult GetPicture(HttpPostedFileBase file)
        {
            int user;
            int.TryParse(Session["User"].ToString(), out user);
            var result = ConvertToByte(file);
            this.user.UpdateImage(result,user);
            return RedirectToAction("Timeline","Home",new { id= user });
        }
        public byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] imgByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imgByte = rdr.ReadBytes((int)file.ContentLength);
            return imgByte;
        }
        public JsonResult AddComment(int postID, int posterID,string content)
        {
            var result = comment.AddComment(new PB_COMMENTS
            {
                POST_ID = postID,
                POSTER_ID= posterID,
                CONTENT =content,
                DATE_CREATED = DateTime.Now
                
            });
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddFriend(int userID, int friendID)
        {
            var result = friend.AddFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AcceptFriend(int userID,int friendID)
        {
            var result = friend.AcceptFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNotifCount(int user){
            var result = notif.GetListOfNotifications(user).Count();
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RejectFriend(int userID, int friendID)
        {
            var result = friend.RejectFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult AddPic(string image)
        //{
        //    var result = ImageManager.byteArrayToImage(image);
        //    return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        //}
    }
}