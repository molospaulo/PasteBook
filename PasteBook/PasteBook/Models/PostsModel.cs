using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class PostsModel
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string PosterID { get; set; }
        public int Poster { get; set; }
        public int countOfLikes { get; set; }
    }
}