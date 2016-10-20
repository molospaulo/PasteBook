using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class IndexViewModel
    {
        public PB_USER User { get; set; }
        public List<PB_REF_COUNTRY> listOfCountries { get; set; }
        public PB_USER LoginUser { get; set; }

        public IndexViewModel()
        {
            listOfCountries = new List<PB_REF_COUNTRY>();
        }
    }
}