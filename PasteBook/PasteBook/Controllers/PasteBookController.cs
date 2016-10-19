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
        HomeManager hManager = new HomeManager();
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
                var user =hManager.GetUserID(model.LoginUser.EmailAddress);

                Session["User"] = user;

                return RedirectToAction("Home","Home",null);
            }
            else
            {
                ModelState.AddModelError("LoginUser.Password", "Invalid Username or Password");
                return View("Index", modelForCountry);
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

 
    }
}