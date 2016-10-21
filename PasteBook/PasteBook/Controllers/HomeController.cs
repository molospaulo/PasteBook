using PasteBookBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookModel;
using PasteBookDataAccess;

namespace PasteBook.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        HomeBL manager = new HomeBL();
        HomeDataAccess dManager = new HomeDataAccess();
        
        [HttpGet]
        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = manager.GetUserPartialDetails(user);
                HomeViewModel model = new HomeViewModel();
                model.User = result;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index","PasteBook");
            }
        }
        public JsonResult GetUserID(string emailAddress)
        {
            var result = manager.GetUserID(emailAddress);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddOrDeleteLike(int postID, int ID)
        {
            string status = "";
            var result = manager.AddOrDeleteLike(ID, postID, out status);
            return Json(new { result = result, status = status }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddPost(int userId, string post, int ProfileOwnerID)
        {
            var result = manager.AddPost(userId, post, ProfileOwnerID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Newsfeed(int id)
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = manager.NewsFeedPostsWithComments(user,dManager.GetListOfPost(id));
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
                
                var result = manager.NewsFeedPostsWithComments(id, dManager.GetListOfPostTimeline(id));
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
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                if (user != id)
                {
                    ViewBag.isFriend = manager.IsFriend(user, id);
                }
                else
                {
                    ViewBag.isFriend = "me";
                }
                var result = manager.GetUserProfileDetails(id);
                HomeViewModel model = new HomeViewModel();
                model.User = result;
                return View(model);
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
                var result = manager.GetUserFriends(user);
                HomeViewModel model = new HomeViewModel();
                model.Users = result;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        public JsonResult AddComment(int postID, int posterID,string content)
        {
            var result = manager.AddComment(postID, posterID, content);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

    }
}