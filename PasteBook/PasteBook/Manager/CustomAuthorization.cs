using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook.Manager
{
        public class CustomAuthorization : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var user = httpContext.Session["ID"];

                if (user == null)
                {
                    return false;
                }

                return true;
            }
        }
 
}