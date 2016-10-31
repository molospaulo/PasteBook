using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
   public class CommentRepository : Repository<PB_COMMENTS>
    {
        public PB_COMMENTS GetOneComment(Func<PB_COMMENTS,bool> condition)
        {
            using (var context = new PasteBookEntities())
            {
                var result = context.PB_COMMENTS
                        .Include("PB_USER")
                        .Include("PB_POSTS")
                        .Where(condition)
                        .Single();
                return result;
            }
        }
    }
}
