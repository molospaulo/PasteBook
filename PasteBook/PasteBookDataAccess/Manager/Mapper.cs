using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess.Entities;
using PasteBookModel;
namespace PasteBookDataAccess.Manager
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
               
                
            };
        }
    }
}
