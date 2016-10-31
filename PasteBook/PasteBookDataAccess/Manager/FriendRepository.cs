using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
   public class FriendRepository :Repository<PB_FRIENDS>
    {
 
       public List<PB_FRIENDS> GetListOfFriends(Func<PB_FRIENDS, bool> condition)
        {
            using (var context = new PasteBookEntities())
            {
                var result = context.PB_FRIENDS
                        .Include("PB_USER")
                        .Include("PB_USER1")
                        .Where(condition)
                        .ToList();
                return result;
            }
        }
        public PB_FRIENDS GetOneFriend(Func<PB_FRIENDS, bool> condition)
        {
      
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_FRIENDS
                            .Include("PB_USER")
                            .Include("PB_USER1")
                            .Where(condition)
                            .SingleOrDefault();
                    return result;
                }
          
        }

    }
}
