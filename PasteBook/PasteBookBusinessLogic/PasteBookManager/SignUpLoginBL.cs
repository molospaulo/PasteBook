using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess;
using PasteBookDataAccess.Entities;
using PasteBookModel;

namespace PasteBookBusinessLogic
{
    public class SignUpLoginBL
    {
        SignUpLoginDataAccess manager = new SignUpLoginDataAccess();
        PasswordManager pManager = new PasswordManager();
        public List<PB_REF_COUNTRY> GetCountries()
        {
            List<PB_REF_COUNTRY> listOfCountries = new List<PB_REF_COUNTRY>();
            var result = manager.GetListOfcountry();
            foreach (var item in result)
            {
                listOfCountries.Add(new PB_REF_COUNTRY { ID = item.ID, COUNTRY = item.COUNTRY });

            }
            return listOfCountries;
        }

        public bool SaveUser(PB_USER model)
        {

            if (model.PASSWORD == model.PASSWORD)
            {
                if (model.GENDER == null)
                {
                    model.GENDER = "U";
                }
                model.DATE_CREATED = DateTime.Now;
                string salt = null;
                string hashPassword = pManager.GenerateHashPassword(model.PASSWORD, out salt);
                model.PASSWORD = hashPassword;
                model.SALT = salt;


                return manager.SaveUser(model);

            }
            else
            {
                return false;
            }
        }


        public bool LoginUser(PB_USER user)
        {
            if (user != null)
            {
                var currentUser = manager.Login(user.EMAIL_ADDRESS);
                if (currentUser != null)
                {
                    bool result = pManager.IsPasswordMatch(user.PASSWORD, currentUser.SALT, currentUser.PASSWORD);
                    return result;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }



        public bool CheckEmail(string email)
        {
            return manager.CheckEmailIfExisting(email);
        }
        public bool CheckUserName(string userName)
        {
            return manager.CheckUsernameIfExisting(userName);
        }

    }
}
