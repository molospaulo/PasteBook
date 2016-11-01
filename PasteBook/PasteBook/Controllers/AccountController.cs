using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookBusinessLogic;
using PasteBookModel;
using PasteBookDataAccess;

namespace PasteBook.Controllers
{
    public class AccountController : Controller
    {
        SignUpLoginBL manager = new SignUpLoginBL();
        UserRepository userRepo = new UserRepository();
        FilterManager filter = new FilterManager();

        // GET: PasteBook
        [HttpGet]
        public ActionResult SignUp()
        {
            List<SelectListItem> listOfGender = new List<SelectListItem>();
            listOfGender.Add(new SelectListItem { Value = "F", Text = "Female" });
            listOfGender.Add(new SelectListItem { Value = "M", Text = "Male" });

            ViewBag.Gender = listOfGender;
            ViewBag.Countries =new SelectList(manager.GetCountries(), "ID" , "Country");
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(PB_USER model)
        {
            List<SelectListItem> listOfGender = new List<SelectListItem>();
            listOfGender.Add(new SelectListItem { Value = "F", Text = "Female" });
            listOfGender.Add(new SelectListItem { Value = "M", Text = "Male" });
            if (userRepo.CheckIfExist(x => x.USER_NAME == model.USER_NAME))
            {
                ModelState.AddModelError("USER_NAME", "Username is already taken");
            }
            if(userRepo.CheckIfExist(x => x.EMAIL_ADDRESS == model.EMAIL_ADDRESS))
            {
                ModelState.AddModelError("EMAIL_ADDRESS", "Email address is already taken");
            }
            if (ModelState.IsValid)
            {
                bool result = manager.SaveUser(model);
                Session["User"] = model.USER_NAME;
                Session["ID"] = model.ID;
                Session["FirstName"] = model.FIRST_NAME;
                Session["LastName"] = model.LAST_NAME;
            }else
            {

                ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
                ViewBag.Gender = listOfGender;
                return View();
            }
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            ViewBag.Gender = listOfGender;
            return RedirectToAction("Home","Home");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PB_USER model)
        {   if (ModelState.IsValidField("EMAIL_ADDRESS") && ModelState.IsValidField("PASSWORD"))
            {
                ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
                if (manager.LoginUser(model))
                {
                    var entry = userRepo.GetOneRecord(x=>x.EMAIL_ADDRESS == model.EMAIL_ADDRESS);

                    Session["User"] = entry.USER_NAME;
                    Session["ID"] = entry.ID;
                    Session["FirstName"] = entry.FIRST_NAME;
                    Session["LastName"] = entry.LAST_NAME;
                    return RedirectToAction("Home", "Home", null);
                }
                else
                {
                    ModelState.AddModelError("EMAIL_ADDRESS", "Invalid Username or Password");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }

        public JsonResult CheckEmail(string email)
        {
            var result = userRepo.CheckIfExist(x => x.EMAIL_ADDRESS == email);
            return Json(new {result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckUsername(string userName)
        {
            var result = userRepo.CheckIfExist(x => x.USER_NAME == userName);
            return Json(new {result = result }, JsonRequestBehavior.AllowGet);
        }

 
    }
}