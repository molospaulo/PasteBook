using PasteBookBusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookModel;
using PasteBookDataAccess;
using PasteBook.Manager;

namespace PasteBook.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        Post post = new Post();
        Friend friend = new Friend();
        User user = new User();
        Notification notif = new Notification();
        UserRepository userRepo = new UserRepository();
        PostRepository postRepo = new PostRepository();
        NotificationRepository notifRepo = new NotificationRepository();



        [HttpGet]
        [Route("PasteBook/Home")]
        [CustomAuthorization]
        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                var result = userRepo.GetOneRecord(x => x.USER_NAME == Session["User"].ToString());
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        [Route("{username}")]
        [CustomAuthorization]
        public ActionResult Timeline(string username)
        {
            if (Session["User"] != null)
            {
                var result = userRepo.GetUserDetailWithCountry(x => x.USER_NAME == username);
                ViewBag.friend = friend.IsFriend(int.Parse(Session["ID"].ToString()),result.ID);
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult Newsfeed()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["ID"].ToString(), out user);
                var result = post.GetListOfPostNewsFeed(user);
                return PartialView("PartialViewNewsFeed", result);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult TimelineFeed(int id)
        {
         if (Session["User"] != null)
            {
                
                var result = postRepo.GetListOfTimelinePosts(id);
                return PartialView("PartialViewNewsFeed", result);
            }
            else
            {
                return RedirectToAction("Index", "PasteBook");
            }
        }
        [CustomAuthorization]
        public ActionResult Search(string keyword)
        {
            var result = user.SearchListOfUsers(keyword);
            return View(result);
        }

        [Route("Friends")]
        [CustomAuthorization]
        public ActionResult Friends()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["ID"].ToString(), out user);
                var result = friend.GetUserFriends(user);
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult AddFriendView(int id)
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["ID"].ToString(), out user);
                ViewBag.isFriend = friend.IsFriend(user, id);
                ViewBag.id = id;
                return PartialView("PartialViewFriendRequest", new { id = id });
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult NotificationView()
        {
            int user;
            int.TryParse(Session["ID"].ToString(), out user);
            var result = notifRepo.GetListOfNotificationWithLimit(x => x.RECEIVER_ID == user);
            return PartialView("PartialViewNotification", result);

        }
    }
}