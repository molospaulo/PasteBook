using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class IndexViewModel
    {
        public UserDetailsModel User { get; set; }
        public List<CountryModel> listOfCountries { get; set; }
        public UserCredentialModel LoginUser { get; set; }

        public IndexViewModel()
        {
            listOfCountries = new List<CountryModel>();
        }
    }
}