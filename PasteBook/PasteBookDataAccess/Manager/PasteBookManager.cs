using PasteBookDataAccess.Entities;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
   public class PasteBookManager
    {
        /// <summary>
        /// Retrieve the list of countries in the database
        /// </summary>
        /// <returns></returns>
        public List<Country> GetListOfcountry()
        {
            List<Country> listOfCountry = new List<Country>() ;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_REF_COUNTRY.ToList();
                    foreach (var item in result)
                    {
                        listOfCountry.Add(new Country { CountryID = item.ID, Name = item.COUNTRY });
                    }
                }
            }
            catch (Exception e)
            {
                return new List<Country>() { };
            }

            return listOfCountry;
        }



    /// <summary>
    /// Save User in the database
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
        public bool SaveUser(UserDetails user)
        {
            bool returnValue = false;

            try
            {
                using (var context = new PasteBookEntities())
                {
                    byte[] array = new byte[4];
                     context.PB_USER.Add(new PB_USER
                    {
                        FIRST_NAME = user.FirstName,
                        LAST_NAME = user.LastName,
                        USER_NAME = user.UserName,
                        PASSWORD = user.Password,
                        SALT = user.Salt,
                        BIRTHDATE = user.Birthdate,
                        COUNTRY_ID = user.CountryID,
                        MOBILE_NO = user.MobileNumber,
                        GENDER = user.Gender,
                        PROFILE_PIC = array,
                        DATE_CREATED = user.DateCreated,
                        ABOUT_ME = user.AboutMe,
                        EMAIL_ADDRESS = user.EmailAddress

                    });
                    var result = context.SaveChanges();
                    returnValue = result != 0 ? true : false;
                  
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return returnValue;
        }

        public bool CheckUsernameIfExisting(string username)
        {
           
            try{
                using(var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Any(x => x.USER_NAME == username);
                    return result;
                }
                }catch(Exception e)
            {
                return false;
            }
        }
        public bool CheckEmailIfExisting(string email)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Any(x => x.EMAIL_ADDRESS == email);
                    return result;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public UserCredentials Login(string emailAddress)
        {
            try
            {
                if (CheckEmailIfExisting(emailAddress))
                {
                    using (var context = new PasteBookEntities())
                    {
                        var result = context.PB_USER.Where(x => x.EMAIL_ADDRESS == emailAddress).Single();

                        return new UserCredentials { EmailAddress = result.EMAIL_ADDRESS, PasswordHash = result.PASSWORD, Salt = result.SALT };
                    }

                }else
                {
                    return null;
                }
            } catch(Exception e)
            {
                return null;
            }
        }

    }
}
