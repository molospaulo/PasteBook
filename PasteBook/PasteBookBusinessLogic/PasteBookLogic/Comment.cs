using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic { 
    public class Comment
    {
    GenericDataAccess<PB_COMMENTS> genericDataAccess = new GenericDataAccess<PB_COMMENTS>();
        public bool AddComment(PB_COMMENTS comment)
        {
            var result = genericDataAccess.AddRow(comment);
            if (result)
            {
                Notification notif = new Notification();
                var newComment = genericDataAccess.GetOneRecord(x => x.ID == comment.ID, x => x.PB_USER,x=>x.PB_POSTS);
                if (comment.POSTER_ID != newComment.PB_POSTS.POSTER_ID)
                {
                    var notification = notif.AddNotification(new PB_NOTIFICATION
                    {
                        RECEIVER_ID = newComment.PB_POSTS.POSTER_ID,
                        NOTIF_TYPE = "C",
                        SENDER_ID = newComment.PB_USER.ID,
                        CREATED_DATE = newComment.DATE_CREATED,
                        POST_ID = newComment.POST_ID,
                        COMMENT_ID = newComment.ID,
                        SEEN = "N"

                    });
                }
            }
            return result;
        }
    }
}
