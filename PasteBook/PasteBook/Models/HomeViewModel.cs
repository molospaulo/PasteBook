using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class HomeViewModel
    {

        public List<PostsModel> listOfPosts { get; set; }
        public UsersPartialDetailsUI UserPartial { get; set; }
        

        public HomeViewModel()
        {
            listOfPosts = new List<PostsModel>();
        }

    }
}