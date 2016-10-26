using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookBusinessLogic;
using PasteBookModel;

namespace PasteBook.Controllers
{
    public class PasteBookController : Controller
    {
        SignUpLoginBL manager = new SignUpLoginBL();
        User user = new User();

        // GET: PasteBook
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Countries =new SelectList(manager.GetCountries(), "ID" , "Country");
            return View();
        }
        [HttpPost]
        public ActionResult Index(PB_USER model)
        {
            bool result = manager.SaveUser(model);
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            Session["User"] = user;
            return RedirectToAction("Home","Home",null);
        }
        [HttpPost]
        public ActionResult Login(string emailAddress,string password)
        {
            PB_USER model = new PB_USER();
            model.EMAIL_ADDRESS = emailAddress;
            model.PASSWORD = password;
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            if (manager.LoginUser(model))
            {
                var user =this.user.GetUserID(model.EMAIL_ADDRESS);

                Session["User"] = user;
                
                return RedirectToAction("Home","Home",null);
            }
            else
            {
                ModelState.AddModelError("errorMessage", "Invalid Username or Password");
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

 
    }
}