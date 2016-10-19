using PasteBookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class MapperUI
    {
        public UserDetails MapUserDetails(UserDetailsModel model)
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
        public UserDetailsModel MapUserDetailsToUI(UserDetails model)
        {
            return new UserDetailsModel()
            {
                UserName = model.UserName,
                Password = model.Password,
                Salt = model.Salt,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.Birthdate,
                Country = model.CountryID,
                MobileNumber = model.MobileNumber,
                Gender = model.Gender,
                ProfilePic = model.ProfilePic,
                DateCreated = model.DateCreated,
                AboutMe = model.AboutMe,
                EmailAddress = model.EmailAddress

            };
        }
        public PostsModel MapPosts(Post posts)
        {
            return new PostsModel
            {
                ID = posts.ID,
                CreatedDate = posts.DateCreated,
                Content = posts.Content,
                Poster = posts.Poster,
                countOfLikes =posts.countOfLikes



            };




        }
    }
}