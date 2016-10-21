using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class PostDataAccess
    {
        public List<PB_POSTS> GetListOfPost(int UserID)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = (from post in context.PB_POSTS
                                  from friend in context.PB_FRIENDS
                                  where (post.POSTER_ID == friend.FRIEND_ID || post.POSTER_ID == friend.USER_ID)
                                  && (friend.USER_ID == UserID || friend.FRIEND_ID == UserID)
                                  && friend.REQUEST == "N" && friend.IsBLOCKED == "N"
                                  select post).Distinct().OrderByDescending(x => x.CREATED_DATE).ToList();
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
