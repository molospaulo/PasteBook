using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class FilterManager 
    {
        public PB_USER trim(PB_USER user)
        {
            PB_USER newUser = new PB_USER();
            newUser.ABOUT_ME = user.ABOUT_ME.Trim();
            newUser.EMAIL_ADDRESS = user.EMAIL_ADDRESS.Trim();
            newUser.FIRST_NAME = user.FIRST_NAME.Trim();
            newUser.LAST_NAME = user.LAST_NAME.Trim();
            newUser.MOBILE_NO = user.MOBILE_NO.Trim();
            newUser.USER_NAME = user.USER_NAME.Trim();
            return newUser;

        }
        public string trimOneString(string data)
        {
            data = data.Trim();
            return data;
        }
            public bool checkAboutMe(string aboutMe)
        {
            if (aboutMe.Length > 2000)
            {
                return false;
            }
            return true;

        }

    }
}