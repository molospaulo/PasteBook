using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class UserRepository : Repository<PB_USER>
    {
        public PB_USER GetUserDetailWithCountry(Func<PB_USER,bool> condition)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER
                        .Include("PB_REF_COUNTRY")
                        .Include("PB_POSTS")
                        .Where(condition)
                        .Single();
                    return result;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
