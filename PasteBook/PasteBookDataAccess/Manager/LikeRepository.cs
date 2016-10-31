using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookModel;

namespace PasteBookDataAccess
{
   public class LikeRepository : Repository<PB_LIKES>
    {
        public PB_LIKES GetOneLike(Func<PB_LIKES,bool> condition)
        {
            using(var context = new PasteBookEntities())
            {
                var result = context.PB_LIKES
                        .Include("PB_POSTS")
                        .Include("PB_USER")
                        .Include("PB_POSTS.PB_USER1")
                        .Where(condition)
                        .Single();
                return result;
            }
        }
    }
}
