using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class Post
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int ProfileOwnerID { get; set; }
        public DateTime DateCreated { get; set; }
        public int IsLiked { get; set; }
        public int Poster { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
