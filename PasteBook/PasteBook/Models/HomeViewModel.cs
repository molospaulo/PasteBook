using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class HomeViewModel
    {

        public PB_USER User { get; set; }
        public List<PB_USER> Users { get; set; }

        public HomeViewModel()
        {
            Users = new List<PB_USER>();
        }
    }
}