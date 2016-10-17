using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class UserCredentials
    {
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
