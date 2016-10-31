using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess;
using PasteBookModel;

namespace PasteBookBusinessLogic
{
    public class SignUpLoginBL
    {
        CountryRepository countryRepo = new CountryRepository();
        PasswordManager pManager = new PasswordManager();
        UserRepository userRepo = new UserRepository();
        public List<PB_REF_COUNTRY> GetCountries()
        {
            return countryRepo.RetrieveAllList();
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


                return userRepo.AddRow(model);

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
                var currentUser = userRepo.GetOneRecord(x => x.EMAIL_ADDRESS == user.EMAIL_ADDRESS);
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


    }
}
