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
        UserRepository userRepo = new UserRepository();
        PasswordManager pm = new PasswordManager();
        public bool checkIfExist(int id)
        {
            return userRepo.CheckIfExist(x => x.ID.Equals(id));
        }
        public List<PB_USER> SearchListOfUsers(string keyword)
        {
            List<PB_USER> users = new List<PB_USER>();
            var result = userRepo.Find(x => x.FIRST_NAME == keyword || x.LAST_NAME == keyword);
            foreach (var item in result)
            {
                users.Add(item);
            }
            return users;
        }
        public bool UpdateImage(byte[] image, string username)
        {
            var user = userRepo.GetOneRecord(x=>x.USER_NAME == username);
            user.PROFILE_PIC = image;
            var result = userRepo.UpdateRow(user);
            return result;
        }
        public bool UpdateAboutMe(string aboutMe, string id)
        {
            var user = userRepo.GetOneRecord(x => x.USER_NAME == id);
            user.ABOUT_ME = aboutMe;
            var result = userRepo.UpdateRow(user);
            return result;
        }
        public bool UpdateProfileDetails(PB_USER user)
        {
            var record = userRepo.GetOneRecord(x => x.ID == user.ID);
            record.USER_NAME = user.USER_NAME;
            record.FIRST_NAME = user.FIRST_NAME;
            record.LAST_NAME = user.LAST_NAME;
            record.COUNTRY_ID = user.COUNTRY_ID;
            record.GENDER = user.GENDER;
            record.MOBILE_NO = user.MOBILE_NO;
            record.BIRTHDATE = user.BIRTHDATE;
            var result = userRepo.UpdateRow(record);

            return result;
        }
        public bool UpdateUserCredential(PB_USER user)
        {
            string salt;
            user.PASSWORD = pm.GenerateHashPassword(user.PASSWORD,out salt);
            var record = userRepo.GetOneRecord(x => x.ID == user.ID);
            record.SALT = salt;
            record.PASSWORD = user.PASSWORD;
            var result = userRepo.UpdateRow(record);
            return result;
        }
        public bool UpdateUserEmail(PB_USER user)
        {
            var record = userRepo.GetOneRecord(x => x.ID == user.ID);
            record.EMAIL_ADDRESS = user.EMAIL_ADDRESS;
            var result = userRepo.UpdateRow(record);
            return result;
        }
        public bool CheckPassword(int id,string password)
        {
            var record = userRepo.GetOneRecord(x => x.ID == id);
            return pm.IsPasswordMatch(password, record.SALT, record.PASSWORD);
        }
    }
}
