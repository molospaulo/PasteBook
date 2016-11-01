using PasteBook.Manager;
using PasteBookBusinessLogic;
using PasteBookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        Notification notif = new Notification();
        NotificationRepository notifRepo = new NotificationRepository();
        public JsonResult GetNotifCount()
        {
            int result = 0;
            if (Session["User"] != null)
            {
                int userID;
                int.TryParse(Session["ID"].ToString(), out userID);
                result = notifRepo.GetListOfNotification(x => (x.RECEIVER_ID == userID && x.SEEN == "N")).Count();
            }

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorization]
        public ActionResult Notification()
        {
            int userID;
            int.TryParse(Session["ID"].ToString(), out userID);
            var notifs = notifRepo.GetListOfNotification(x => x.RECEIVER_ID == userID);
            return View(notifs);
        }

        public JsonResult SeenNotif()
        {
            int userID;
            int.TryParse(Session["ID"].ToString(), out userID);
            var notifs = notifRepo.GetListOfNotification(x => (x.RECEIVER_ID == userID && x.SEEN == "N"));
            var result = notif.UpdateNotifications(notifs);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}