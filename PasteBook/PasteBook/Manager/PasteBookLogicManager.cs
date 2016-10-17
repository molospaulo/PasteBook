using PasteBookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class PasteBookLogicManager
    {
        PasteBookManager manager = new PasteBookManager();
        MapperUI map = new MapperUI();
        PasswordManager pManager = new PasswordManager();
        public List<CountryModel> GetCountries()
        {
            List<CountryModel> listOfCountries = new List<CountryModel>();
           var result = manager.GetListOfcountry();
            foreach (var item in result)
            {
                listOfCountries.Add(new CountryModel { CountryID = item.CountryID, Name = item.Name });

            }
            return listOfCountries;
        }

        public bool SaveUser(UserDetailsModel model)
        {
            
            if (model.Password == model.ConfirmPassword)
            {
                if (model.Gender == null)
                {
                    model.Gender = "U";
                }
                model.DateCreated = DateTime.Now;
                string salt = null;
                string hashPassword = pManager.GenerateHashPassword(model.Password, out salt);
                model.Password = hashPassword;
                model.Salt = salt;


                return manager.SaveUser(map.MapUserDetails(model));

            }else
            {
                return false;
            }
        }

        public bool LoginUser(UserCredentialModel user)
        {
            var currentUser = manager.Login(user.EmailAddress);
            if (currentUser != null)
            {
                bool result = pManager.IsPasswordMatch(user.Password, currentUser.Salt, currentUser.PasswordHash);
                return result;
            }
            else {
                return false;
            }
        }

        public bool checkEmail(string email)
        {
            return manager.CheckEmailIfExisting(email);
        }
        public bool checkUserName(string userName)
        {
            return manager.CheckUsernameIfExisting(userName);
        }
    }
}		
