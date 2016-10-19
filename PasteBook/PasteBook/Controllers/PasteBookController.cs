using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PasteBook.Controllers
{
    public class PasteBookController : Controller
    {
        PasteBookLogicManager manager = new PasteBookLogicManager();
        static IndexViewModel modelForCountry = new IndexViewModel();
        // GET: PasteBook
        [HttpGet]
        public ActionResult Index()
        {

            modelForCountry.listOfCountries = manager.GetCountries();
            return View(modelForCountry);
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "User")]IndexViewModel model)
        {
            bool result = manager.SaveUser(model.User);

            return View(modelForCountry);
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "LoginUser")]IndexViewModel model)
        {
            if (manager.LoginUser(model.LoginUser))
            {
                var user =manager.GetUserID(model.LoginUser.EmailAddress);

                Session["User"] = user;

                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("LoginUser.Password", "Invalid Username or Password");
                return View("Index", modelForCountry);
            }
        }
        [HttpGet]
        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                int user;
                int.TryParse(Session["User"].ToString(), out user);
                var result = manager.GetListOfPosts(user);
                return View(result);
            }else
            {
                return RedirectToAction("Index");
            }
        }



       public JsonResult CheckEmail(string email)
        {
           var result= manager.CheckEmail(email);
            return Json(new {result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckUsername(string userName)
        {
            var result = manager.CheckUserName(userName);
            return Json(new {result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserID(string emailAddress)
        {
            var result = manager.GetUserID(emailAddress);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddOrDeleteLike(int postID,int ID)
        { string status = "";
            var result = manager.AddOrDeleteLike(ID,postID,out status);
            return Json(new { result = result ,status =status }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPost(int userId , string post , int ProfileOwnerID)
        {
            var result = manager.AddPost(userId, post, ProfileOwnerID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult RefreshNewsfeed()
        {
            int user;
            int.TryParse(Session["User"].ToString(), out user);
            var result = manager.GetListOfPosts(user);
            return this.PartialView("PartialViewNewsFeed",result);
        }
        public ActionResult UserProfile()
        {
            
            return View();
        }
    }
}