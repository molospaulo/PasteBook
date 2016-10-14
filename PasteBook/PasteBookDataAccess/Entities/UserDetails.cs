using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class UserDetails
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string CountryID { get; set; }
        public string MobileNumber { get; set; }
        public char Gender { get; set; }
        public byte[] ProfilePic { get; set; }
        public DateTime DateCreated { get; set; }
        public string AboutMe { get; set; }
        public string EmailAddress { get; set; }
     }
}
