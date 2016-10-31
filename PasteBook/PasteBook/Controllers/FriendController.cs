using PasteBookBusinessLogic;
using PasteBookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friends
        FriendRepository friendRepo = new FriendRepository();
        Friend friend = new Friend();
        public ActionResult Index()
        {
            return View();
        }
  
        public JsonResult AddFriend(int userID, int friendID)
        {
            var result = friend.AddFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AcceptFriend(int userID, int friendID)
        {
            var result = friend.AcceptFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RejectFriend(int userID, int friendID)
        {
            var result = friend.RejectFriend(userID, friendID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }


    }
}