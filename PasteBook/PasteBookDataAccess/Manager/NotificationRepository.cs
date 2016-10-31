using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookModel;

namespace PasteBookDataAccess
{
    public class NotificationRepository :Repository<PB_NOTIFICATION>
    {
        public List<PB_NOTIFICATION> GetListOfNotification(Func<PB_NOTIFICATION,bool> condition)
        {
            using(var context = new PasteBookEntities())
            {
                var result = context.PB_NOTIFICATION
                    .Include("PB_USER")
                    .Include("PB_USER1")
                    .Include("PB_COMMENTS")
                    .Include("PB_POSTS")
                    .Where(condition)
                    .OrderByDescending(x => x.CREATED_DATE)
                    .ToList();
                return result;
            }
        }
        public List<PB_NOTIFICATION> GetListOfNotificationWithLimit(Func<PB_NOTIFICATION, bool> condition)
        {
            using (var context = new PasteBookEntities())
            {
                var result = context.PB_NOTIFICATION
                    .Include("PB_USER")
                    .Include("PB_USER1")
                    .Include("PB_COMMENTS")
                    .Include("PB_POSTS")
                    .Where(condition)
                    .OrderByDescending(x => x.CREATED_DATE)
                    .Take(20)
                    .ToList();
                return result;
            }
        }
        public PB_NOTIFICATION GetOneNotification(Func<PB_NOTIFICATION, bool> condition)
        {
            using (var context = new PasteBookEntities())
            {
                var result = context.PB_NOTIFICATION
                    .Include("PB_USER")
                    .Include("PB_USER1")
                    .Include("PB_COMMENTS")
                    .Include("PB_POSTS")
                    .Where(condition)
                    .SingleOrDefault();
                return result;
            }
        }
    }
}
