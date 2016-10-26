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
        SignUpLoginBL manager = new SignUpLoginBL();
        PasswordManager pManager = new PasswordManager();
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

        public JsonResult AddOrDeleteLike(int postID)
        {
            string status = "";
            int user;
            int.TryParse(Session["User"].ToString(), out user);
            var result = like.AddOrDeleteLike(user, postID, out status);
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
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "PasteBook");
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
        public ActionResult FriendRequestView()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = notif.GetListOfFriendRequestNotifs(user);
                return PartialView("PartialViewFriendRequestNotif", result);
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
        public ActionResult Posts(int id)
        {
            var result = post.GetPost(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            int user;
            int.TryParse(Session["User"].ToString(), out user);
            var result = this.user.GetUser(user);
            result.PASSWORD = null;
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            return View(result);
        }
       
        [HttpPost]
       public ActionResult EditProfile(PB_USER model)
        {
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            model.ID = userID;
            this.user.UpdateProfileDetails(model);
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            return View();
        }
        [HttpGet]
        public ActionResult EditPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EditPassword(PB_USER model, string confirmPassword,string newPassword)
        {
   
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            model.ID = userID;
            if (newPassword == confirmPassword)
            {
                if (user.CheckPassword(model.ID, model.PASSWORD))
                {
                    user.UpdateUserCredential(model);
                }else
                {
                    ModelState.AddModelError("Password", "Old password did not match");
                }
            }
            else
            {
                ModelState.AddModelError("ConfirmPassword", "Confirm password did not match with new password");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmail()
        {
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            var result = this.user.GetUser(userID);
            result.PASSWORD = null;
            return View(result);
        }
        [HttpPost]
        public ActionResult EditEmail(PB_USER model)
        {
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            model.ID = userID;
                if (user.CheckPassword(model.ID,model.PASSWORD))
                {
                    user.UpdateUserEmail(model);
                }
                else
                {
                    ModelState.AddModelError("PASSWORD", "Old password did not match");
                }
            
            return View();
        }
        public ActionResult Search(string keyword)
        {
            var result = user.SearchListOfUsers(keyword);
            return View(result);
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
        public ActionResult AddAboutMe(string aboutMe)
        {
            int user;
            int.TryParse(Session["User"].ToString(), out user);
            this.user.UpdateAboutMe(aboutMe, user);
            return RedirectToAction("Timeline", "Home", new { id = user });
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
        public JsonResult GetNotifCount(){
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            var result = notif.GetListOfUnSeenNotifications(userID).Count();
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RejectFriend(int userID, int friendID)
        {

            var result = friend.RejectFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFriendRequestCount()
        {
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            var result = notif.GetListOfUnSeenFriendNotifications(userID).Count();
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SeenNotif()
        {
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            var notifs = notif.GetListOfNotifications(userID);
            var result = notif.UpdateNotifications(notifs);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Notification()
        {
            int userID;
            int.TryParse(Session["User"].ToString(), out userID);
            var notifs = notif.GetListOfNotifications(userID);
            return View(notifs);
        }
    }
}