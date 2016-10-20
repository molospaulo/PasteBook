using PasteBookDataAccess.Entities;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
   public class SignUpLoginDataAccess
    {
        Mapper map = new Mapper();
        /// <summary>
        /// Save User in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveUser(PB_USER user)
        {
            bool returnValue = false;

            try
            {
                using (var context = new PasteBookEntities())
                {

                    context.PB_USER.Add(user);
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

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Any(x => x.USER_NAME == username);
                    return result;
                }
            }
            catch (Exception e)
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

        public PB_USER Login(string emailAddress)
        {
            try
            {
                if (CheckEmailIfExisting(emailAddress))
                {
                    using (var context = new PasteBookEntities())
                    {
                        var result = context.PB_USER.Where(x => x.EMAIL_ADDRESS == emailAddress).Single();

                        return result;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        /// <summary>
        /// Retrieve the list of countries in the database
        /// </summary>
        /// <returns></returns>
        public List<PB_REF_COUNTRY> GetListOfcountry()
        {
            List<PB_REF_COUNTRY> listOfCountry = new List<PB_REF_COUNTRY>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_REF_COUNTRY.ToList();
                    foreach (var item in result)
                    {
                        listOfCountry.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                return new List<PB_REF_COUNTRY>() { };
            }

            return listOfCountry;
        }
    }
}
