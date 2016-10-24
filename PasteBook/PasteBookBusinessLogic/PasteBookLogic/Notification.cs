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
        GenericDataAccess<PB_NOTIFICATION> genericDataAccess = new GenericDataAccess<PB_NOTIFICATION>();
        public List<PB_NOTIFICATION> GetListOfNotifications(int id)
        {
            var result = genericDataAccess.RetrieveListWithCondition(x => (x.RECEIVER_ID == id && x.SEEN == "N"), x => x.PB_USER,x =>x.PB_USER1,x => x.PB_COMMENTS,x =>x.PB_POSTS).OrderByDescending(x => x.CREATED_DATE).ToList();
            return result;
        }
        public bool AddNotification(PB_NOTIFICATION notif)
        {
            var result = genericDataAccess.AddRow(notif);
            return result;
        }
        public bool UpdateNotification(PB_NOTIFICATION notif)
        {
            var result = genericDataAccess.UpdateRow(notif);
            return result;
        }
    }
}
