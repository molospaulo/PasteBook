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
        CommentRepository commentRepo = new CommentRepository();
        public bool AddComment(PB_COMMENTS comment)
        {
            var result = commentRepo.AddRow(comment);
            if (result)
            {
                NotificationRepository notifRepo = new NotificationRepository();
                var newComment = commentRepo.GetOneComment(x => x.ID == comment.ID);
                if (comment.POSTER_ID != newComment.PB_POSTS.POSTER_ID)
                {
                    var notification = notifRepo.AddRow(new PB_NOTIFICATION
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
