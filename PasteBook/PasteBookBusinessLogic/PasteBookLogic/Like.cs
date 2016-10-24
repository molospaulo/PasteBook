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
            if ( genericDataAccess.CheckIfExist(x => x.POST_ID == postID && x.LIKED_BY == ID)) { 
                status = "deletelike";
                return genericDataAccess.RemoveRow(x => x.POST_ID == postID && x.LIKED_BY == ID);
            }
            else
            {
                status = "addlike";
                    var result = genericDataAccess.AddRow(new PB_LIKES
                    {
                        POST_ID = postID,
                        LIKED_BY = ID,
                    });
                if (result)
                {
                    var like = genericDataAccess.GetOneRecord(x => (x.POST_ID == postID && x.LIKED_BY == ID),x => x.PB_POSTS,x=>x.PB_USER);
                    Notification notif = new Notification();
                    notif.AddNotification(new PB_NOTIFICATION {
                        RECEIVER_ID = like.PB_POSTS.PB_USER.ID,
                        NOTIF_TYPE ="L",
                        SENDER_ID = like.LIKED_BY,
                        CREATED_DATE = DateTime.Now,
                        POST_ID = like.POST_ID,
                        SEEN ="N"
                        
                    });
                }
                
                return result;
            }
        }
    }
}