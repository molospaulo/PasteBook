using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// objectQuery :https://blogs.msdn.microsoft.com/alexj/2009/06/02/tip-22-how-to-make-include-really-include/ 
namespace PasteBookDataAccess
{
    public class PostDataAccess
    {
        public List<PB_POSTS> GetListOfPost(int UserID)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = ((from post in context.PB_POSTS
                                  from friend in context.PB_FRIENDS
                                  where (post.POSTER_ID == friend.FRIEND_ID || post.POSTER_ID == friend.USER_ID)
                                  && (friend.USER_ID == UserID || friend.FRIEND_ID == UserID)
                                  && friend.REQUEST == "N" && friend.IsBLOCKED == "N"
                                  select post) as ObjectQuery<PB_POSTS>).Include("PB_USER").Include("PB_USER1").Include("PB_COMMENTS").Include("PB_LIKES").Include("PB_NOTIFICATION")
                                  .Distinct().OrderByDescending(x => x.CREATED_DATE).ToList();
   
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<PB_POSTS>() { };
            }

        }
    }
}
