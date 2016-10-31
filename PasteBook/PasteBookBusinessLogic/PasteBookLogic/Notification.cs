using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess;
using PasteBookModel;

namespace PasteBookBusinessLogic
{
   
    public class Notification
    {
        NotificationRepository notifRepo = new NotificationRepository();
        public bool UpdateNotifications(List<PB_NOTIFICATION> notif)
        {
            bool returnValue = false;
            foreach (var item in notif)
            {
                item.SEEN = "Y";
                var result = notifRepo.UpdateRow(item);
                returnValue = result;
            }

            return returnValue;
        }
        public bool UpdateNotification(PB_NOTIFICATION notif)
        {
            bool returnValue = false;
                notif.SEEN = "Y";
                var result = notifRepo.UpdateRow(notif);
                returnValue = result;
            return returnValue;
        }
        //public List<PB_NOTIFICATION> GetListOfFriendRequestNotifs(int id)
        //{
        //    var result = genericDataAccess.RetrieveListWithCondition(x => (x.RECEIVER_ID == id && x.NOTIF_TYPE == "F" && x.SEEN == "N"), x => x.PB_USER, x => x.PB_USER1, x => x.PB_COMMENTS, x => x.PB_POSTS).OrderByDescending(x => x.CREATED_DATE).Take(20).ToList();
        //    return result;
        //}
        //public PB_NOTIFICATION GetNotification(int id)
        //{
        //    var result = genericDataAccess.GetOneRecord(x => (x.RECEIVER_ID == id && x.NOTIF_TYPE == "F" && x.SEEN == "N"));
        //    return result;
        //}
    }
}
