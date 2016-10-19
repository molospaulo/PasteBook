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
        HomeManager manager = new HomeManager();
        
        [HttpGet]
        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = manager.GetUserPartialDetails(user);
                HomeViewModel model = new HomeViewModel();
                model.UserPartial = result;
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
        public JsonResult AddPost(int userId, string post, int ProfileOwnerID)
        {
            var result = manager.AddPost(userId, post, ProfileOwnerID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        //public PartialViewResult RefreshNewsfeed()
        //{
        //    int user;
        //    int.TryParse(Session["User"].ToString(), out user);
        //    var result = manager.GetListOfPosts(user);
        //    return this.PartialView("PartialViewNewsFeed",result);
        //}
        public ActionResult Newsfeed(int id)
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = manager.GetListOfPosts(user);
                HomeViewModel model = new HomeViewModel();
                model.listOfPosts = result;
                return PartialView("PartialViewNewsFeed", model);
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
                
                var result = manager.GetListOfPosts(id);
                HomeViewModel model = new HomeViewModel();
                model.listOfPosts = result;
                return PartialView("PartialViewNewsFeed", model);
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
            
                var result = manager.GetUserPartialDetails(id);
                HomeViewModel model = new HomeViewModel();
                model.UserPartial = result;
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
                
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
    }
}