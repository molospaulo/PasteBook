using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class UserProfileDetails: UserPartialDetails
    {
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
