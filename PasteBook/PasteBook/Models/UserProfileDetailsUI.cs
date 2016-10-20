using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class UserProfileDetailsUI : UsersPartialDetailsUI
    {

        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}