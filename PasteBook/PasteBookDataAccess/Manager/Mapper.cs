using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess.Entities;
using PasteBookModel;
namespace PasteBookDataAccess
{
    public class Mapper
    {
        public PB_USER MapUser(UserDetails user)
        {
            return new PB_USER {USER_NAME = user.UserName,
                PASSWORD = user.Password,
                SALT = user.Salt,
                FIRST_NAME =user.FirstName,
                LAST_NAME = user.LastName,
                BIRTHDATE = user.Birthdate,
                COUNTRY_ID = user.CountryID,
                MOBILE_NO = user.MobileNumber,
                GENDER = user.Gender,
                PROFILE_PIC = user.ProfilePic,
                DATE_CREATED = user.DateCreated,
                ABOUT_ME = user.AboutMe,
                EMAIL_ADDRESS = user.EmailAddress
                
            };
        }

        public UserDetails MapUserToUI(PB_USER user)
        {
            return new UserDetails
            {
                UserName = user.USER_NAME,
                Password= user.PASSWORD,
                Salt = user.SALT,
                FirstName = user.FIRST_NAME,
                LastName = user.LAST_NAME,
                Birthdate = user.BIRTHDATE,
                CountryID = user.COUNTRY_ID.Value,
                MobileNumber= user.MOBILE_NO,
                Gender = user.GENDER,
                ProfilePic= user.PROFILE_PIC,
                DateCreated= user.DATE_CREATED,
                AboutMe = user.ABOUT_ME,
                EmailAddress = user.EMAIL_ADDRESS

            };
        }

        public Post MapPost(PB_POSTS post)
        {
            return new Post
            {
                ID = post.ID,
                DateCreated = post.CREATED_DATE,
                Content = post.CONTENT,
                ProfileOwnerID = post.PROFILE_OWNER_ID,
                Poster = post.POSTER_ID
            };
        }
    }
}
