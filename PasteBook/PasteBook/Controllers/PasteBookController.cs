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
                Session["User"] = model.LoginUser.EmailAddress;
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
                var user = Session["User"].ToString();
                var result = manager.GetListOfPosts(manager.GetUserID(user));
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

        public JsonResult AddLike(int postID,int ID)
        {
            var result = manager.AddLike(ID,postID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPost(int userId , string post , int ProfileOwnerID)
        {
            var result = manager.AddPost(userId, post, ProfileOwnerID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}