using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess;
using PasteBookModel;

namespace PasteBookBusinessLogic
{
    public class User
    {
        GenericDataAccess<PB_USER> genericDataAccess = new GenericDataAccess<PB_USER>();
        PasswordManager pm = new PasswordManager();
        public IEnumerable<PB_USER> GetListOfUser(int id)
        {
            return genericDataAccess.RetrieveListWithCondition( x => x.ID.Equals(id),x => x.PB_REF_COUNTRY,x => x.PB_POSTS);
        }
        public PB_USER GetUser(int id)
        {
            return genericDataAccess.GetOneRecord(x => x.ID.Equals(id), x => x.PB_REF_COUNTRY,x => x.PB_POSTS);
        }
        public bool checkIfExist(int id)
        {
            return genericDataAccess.CheckIfExist(x => x.ID.Equals(id));
        }
        public List<PB_USER> SearchListOfUsers(string keyword)
        {
            List<PB_USER> users = new List<PB_USER>();
            var result = genericDataAccess.RetrieveListWithCondition(x => x.FIRST_NAME == keyword || x.LAST_NAME == keyword);
            foreach (var item in result)
            {
                users.Add(item);
            }
            return users;
        }
        public int GetUserID(string emailAddress)
        {
           var result = genericDataAccess.GetOneRecord(x => x.EMAIL_ADDRESS == emailAddress);
            return result.ID;
        }
        public bool UpdateImage(byte[] image, int id)
        {
            var user = genericDataAccess.GetOneRecord(x=>x.ID == id);
            user.PROFILE_PIC = image;
            var result = genericDataAccess.UpdateRow(user);
            return result;
        }
        public bool UpdateAboutMe(string aboutMe, int id)
        {
            var user = genericDataAccess.GetOneRecord(x => x.ID == id);
            user.ABOUT_ME = aboutMe;
            var result = genericDataAccess.UpdateRow(user);
            return result;
        }
        public bool UpdateProfileDetails(PB_USER user)
        {
            var record = genericDataAccess.GetOneRecord(x => x.ID == user.ID);
            record.USER_NAME = user.USER_NAME;
            record.FIRST_NAME = user.FIRST_NAME;
            record.LAST_NAME = user.LAST_NAME;
            record.COUNTRY_ID = user.COUNTRY_ID;
            record.GENDER = user.GENDER;
            record.MOBILE_NO = user.MOBILE_NO;
            var result = genericDataAccess.UpdateRow(record);

            return result;
        }
        public bool UpdateUserCredential(PB_USER user)
        {
      
            string salt;
            user.PASSWORD = pm.GenerateHashPassword(user.PASSWORD,out salt);
            var record = genericDataAccess.GetOneRecord(x => x.ID == user.ID);
            record.SALT = salt;
            record.PASSWORD = user.PASSWORD;
            record.EMAIL_ADDRESS = user.EMAIL_ADDRESS;
            var result = genericDataAccess.UpdateRow(record);
            return result;
        }
        public bool CheckPassword(int id,string password)
        {
            var record = genericDataAccess.GetOneRecord(x => x.ID == id);
            return pm.IsPasswordMatch(password, record.SALT, record.PASSWORD);
        }
    }
}
