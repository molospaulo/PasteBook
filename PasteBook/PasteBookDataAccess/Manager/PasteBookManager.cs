using PasteBookDataAccess.Entities;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
   public class PasteBookManager
    {
        public bool SaveUser(UserDetails user)
        {

            using (var context = new PasteBookEntities())
            {
                PB_USER users = new PB_USER();
                


                var result = context.PB_USER.Add(user);
            }
        return true;
        }
    }
}
