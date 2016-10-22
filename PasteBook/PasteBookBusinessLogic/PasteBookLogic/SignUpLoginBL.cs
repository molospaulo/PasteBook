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
        
        PasswordManager pManager = new PasswordManager();
        public List<PB_REF_COUNTRY> GetCountries()
        {
            var dataAccessGeneric = new GenericDataAccess<PB_REF_COUNTRY>();
            return dataAccessGeneric.RetrieveAllList();
        }

        public bool SaveUser(PB_USER model)
        {
            var genericDataAccess = new GenericDataAccess<PB_USER>();
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


                return genericDataAccess.AddRow(model);

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
                var genericDataAccess = new GenericDataAccess<PB_USER>();
                var currentUser = genericDataAccess.GetOneRecord(x => x.EMAIL_ADDRESS == user.EMAIL_ADDRESS);
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
            var genericDataAccess = new GenericDataAccess<PB_USER>();
            return genericDataAccess.CheckIfExist(x => x.EMAIL_ADDRESS == email);
        }
        public bool CheckUserName(string userName)
        {
            var genericDataAccess = new GenericDataAccess<PB_USER>();
            return genericDataAccess.CheckIfExist(x => x.USER_NAME == userName);
        }

    }
}
