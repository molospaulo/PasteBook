using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class NewsFeedViewModel : PB_POSTS
    {
        public List<PB_LIKES> CountOfLikes { get; set; }
        public bool IsLike { get; set; }
        public List<PB_COMMENTS> ListOfComments {get; set;}

        public NewsFeedViewModel()
        {
            ListOfComments = new List<PB_COMMENTS>();
            CountOfLikes = new List<PB_LIKES>();
        }
    }
}
