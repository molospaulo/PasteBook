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
    }
}
