using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class UserCredentialModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}