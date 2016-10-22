using PasteBookBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
        public ActionResult AddPost(int userId, string post, int ProfileOwnerID)
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
                ViewBag.isFriend = "me";
                if (user != id)
                    ViewBag.isFriend = friend.IsFriend(user, id);
                    ViewBag.id = id;
                return PartialView("PartialViewFriendRequest",new { id = id });
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
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        public JsonResult AddComment(int postID, int posterID,string content)
        {
            var result = comment.AddComment(postID, posterID, content);
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
        
    }
}