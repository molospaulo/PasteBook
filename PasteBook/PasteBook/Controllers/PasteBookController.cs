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

        public ActionResult Login([Bind(Include = "LoginUser")]IndexViewModel model)
        {
            if (manager.LoginUser(model.LoginUser))
            {
                Session["User"] = model.LoginUser.EmailAddress;
                return View();
            }
            else
            {
                ModelState.AddModelError("LoginUser.Password","Invalid Username or Password");
                return View("Index", modelForCountry);
            }
        }
       public JsonResult CheckEmail(string email)
        {
           var result= manager.checkEmail(email);
            return Json(new {result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckUsername(string userName)
        {
            var result = manager.checkUserName(userName);
            return Json(new {result = result }, JsonRequestBehavior.AllowGet);
        }



    }
}