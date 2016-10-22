using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class Like
    {
        public bool AddOrDeleteLike(int ID, int postID, out string status)
        {
            var genericDataAccess = new GenericDataAccess<PB_LIKES>();
            if ( genericDataAccess.CheckIfExist(x => x.POST_ID == postID && x.LIKED_BY == ID))
            {
                status = "deletelike";
                return genericDataAccess.RemoveRow(x => x.POST_ID == postID && x.LIKED_BY == ID);
            }
            else
            {
                status = "addlike";
              

                return genericDataAccess.AddRow(new PB_LIKES {
                    POST_ID= postID,
                    LIKED_BY =ID,
                    
                });
            }
        }
    }
}