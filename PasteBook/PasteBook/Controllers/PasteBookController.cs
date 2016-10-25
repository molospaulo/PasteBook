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
            return View();
        }
        [HttpPost]
        public ActionResult Login(PB_USER model)
        {
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            if (manager.LoginUser(model))
            {
                var user =this.user.GetUserID(model.EMAIL_ADDRESS);

                Session["User"] = user;
                
                return RedirectToAction("Home","Home",null);
            }
            else
            {
                ModelState.AddModelError("LoginUser.Password", "Invalid Username or Password");
                return View("Index");
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