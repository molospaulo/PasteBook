using PasteBookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class MapperUI
    {
        public UserDetails MapUserDetails( UserDetailsModel model)
        {
            return new UserDetails()
            {
                UserName = model.UserName,
                Password = model.Password,
                Salt = model.Salt,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthdate = model.Birthday,
                CountryID = model.Country,
                MobileNumber = model.MobileNumber,
                Gender = model.Gender,
                ProfilePic = model.ProfilePic,
                DateCreated = model.DateCreated,
                AboutMe = model.AboutMe,
                EmailAddress = model.EmailAddress

            };
        }
    }
}