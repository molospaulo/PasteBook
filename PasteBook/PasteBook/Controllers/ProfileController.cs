using PasteBookBusinessLogic;
using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        UserRepository userRepo = new UserRepository();
        User user = new User();
        SignUpLoginBL manager = new SignUpLoginBL();
        PasswordManager pManager = new PasswordManager();


        [HttpPost]
        public ActionResult GetPicture(HttpPostedFileBase file)
        {
            ImageManager mgr = new ImageManager();
            string username = Session["User"].ToString();
            var result = mgr.ConvertToByte(file);
            if (mgr.IsImageValid(file))
            {
                this.user.UpdateImage(result, username);
            }// todo error message
            return RedirectToAction("Timeline", "Home", new { username = username });
        }

        public ActionResult AddAboutMe(string aboutMe)
        {
            var username = Session["User"].ToString();
            this.user.UpdateAboutMe(aboutMe, username);
            return RedirectToAction("Timeline", "Home", new { username = username });
        }

        [HttpGet]
        public ActionResult EditProfile()
        {

            var result = userRepo.GetOneRecord(x => x.USER_NAME == Session["User"].ToString());
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            return View(result);
        }

        [HttpPost]
        public ActionResult EditProfile(PB_USER model, string oldUsername)
        {
            if (oldUsername == model.USER_NAME)
            {
                int userID;
                int.TryParse(Session["ID"].ToString(), out userID);
                model.ID = userID;
                this.user.UpdateProfileDetails(model);

            }
            else
            {
                if (userRepo.CheckIfExist(x => x.USER_NAME == model.USER_NAME))
                {
                    ModelState.AddModelError("USER_NAME", "Username is already taken");
                }
                else
                {
                    int userID;
                    int.TryParse(Session["ID"].ToString(), out userID);
                    model.ID = userID;
                    this.user.UpdateProfileDetails(model);
                }
            }
            ViewBag.Countries = new SelectList(manager.GetCountries(), "ID", "Country");
            return View(model);
        }
        [HttpGet]
        public ActionResult EditPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EditPassword(PB_USER model, string confirmPassword, string newPassword)
        {

            int userID;
            int.TryParse(Session["ID"].ToString(), out userID);
            model.ID = userID;
            if (newPassword == confirmPassword)
            {
                if (user.CheckPassword(model.ID, model.PASSWORD))
                {
                    model.PASSWORD = newPassword;
                    user.UpdateUserCredential(model);
                }
                else
                {
                    ModelState.AddModelError("Password", "Old password did not match");
                }
            }
            else
            {
                ModelState.AddModelError("ConfirmPassword", "Confirm password did not match with new password");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmail()
        {

            var result = userRepo.GetOneRecord(x => x.USER_NAME == Session["User"].ToString());
            result.PASSWORD = null;
            return View(result);
        }
        [HttpPost]
        public ActionResult EditEmail(PB_USER model, string oldEmail)
        {
            int userID;
            int.TryParse(Session["ID"].ToString(), out userID);
            if (oldEmail == model.EMAIL_ADDRESS)
            {
                model.ID = userID;
                if (user.CheckPassword(model.ID, model.PASSWORD))
                {
                    user.UpdateUserEmail(model);
                }
                else
                {
                    ModelState.AddModelError("PASSWORD", "Old password did not match");
                }
            }
            else
            {
                if (userRepo.CheckIfExist(x => x.USER_NAME == model.USER_NAME))
                {
                    ModelState.AddModelError("USER_NAME", "Old password did not match");
                }
                else
                {
                    user.UpdateUserEmail(model);
                }
            }
            return View();
        }


    }
}