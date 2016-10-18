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
        public UserDetails Poster { get; set; }
    }
}
