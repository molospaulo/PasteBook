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
            LikeRepository likeRepo = new LikeRepository();
            if ( likeRepo.CheckIfExist(x => x.POST_ID == postID && x.LIKED_BY == ID)) { 
                status = "deletelike";
                var like = likeRepo.GetOneLike(x => (x.POST_ID == postID && x.LIKED_BY == ID));
                return likeRepo.RemoveRow(like);
            }
            else
            {
                status = "addlike";
                    var result = likeRepo.AddRow(new PB_LIKES
                    {
                        POST_ID = postID,
                        LIKED_BY = ID,
                    });
                if (result)
                {
                    var like = likeRepo.GetOneLike(x => (x.POST_ID == postID && x.LIKED_BY == ID));
                    if (like.PB_POSTS.PB_USER.ID!= like.LIKED_BY)
                    {
                        NotificationRepository notif = new NotificationRepository();

                        notif.AddRow(new PB_NOTIFICATION
                        {
                            RECEIVER_ID = like.PB_POSTS.PB_USER.ID,
                            NOTIF_TYPE = "L",
                            SENDER_ID = like.LIKED_BY,
                            CREATED_DATE = DateTime.Now,
                            POST_ID = like.POST_ID,
                            SEEN = "N"

                        });
                    }
                }
                
                return result;
            }
        }
    }
}