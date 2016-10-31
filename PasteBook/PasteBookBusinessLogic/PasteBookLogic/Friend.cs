using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class Friend
    {
        NotificationRepository notifRepo = new NotificationRepository();
        FriendRepository friendRepo = new FriendRepository();
        public List<PB_USER> GetUserFriends(int id)
        {
            List<PB_USER> listOfFriends = new List<PB_USER>();
         
            var output = friendRepo.GetListOfFriends(x => ((x.USER_ID == id || x.FRIEND_ID == id) &&  (x.REQUEST == "N")));
            foreach (var item in output)
            {
                if (item.PB_USER.ID == id)
                {
                    listOfFriends.Add(item.PB_USER1);
                }
                else
                {
                    listOfFriends.Add(item.PB_USER);
                }

            }
            return listOfFriends;
        }
        public string IsFriend(int userID, int profileOwnerID)
        {
            if (userID != profileOwnerID)
            {
                PB_FRIENDS friend = new PB_FRIENDS();
                friend = friendRepo.GetOneFriend(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID ==userID  && x.USER_ID == profileOwnerID));
                if (friend != null)
                {
                    if (friend.PB_USER.ID == userID && friend.PB_USER1.ID == profileOwnerID && friend.REQUEST == "N")
                    {
                        return "friend";
                    }
                    else if (friend.PB_USER.ID == profileOwnerID && friend.PB_USER1.ID == userID && friend.REQUEST == "Y")
                    {
                        return "request";
                    }
                    else if (friend.PB_USER.ID == profileOwnerID && friend.PB_USER1.ID == userID && friend.REQUEST == "N")
                    {
                        return "friend";
                    }
                    else if (friend.PB_USER.ID == userID && friend.PB_USER1.ID == profileOwnerID && friend.REQUEST == "Y")
                    {
                        return "accept";
                    }else
                    {
                        return "notfriend";
                    }

                }
                else
                {
                    return "notfriend";
                }
             }
            else
            {
                return "me";
            }

        }
        public bool AddFriend(int userID, int profileOwnerID)
        {
            var result = friendRepo.AddRow(new PB_FRIENDS {
                USER_ID = userID,
                FRIEND_ID = profileOwnerID,
                REQUEST ="Y",
                IsBLOCKED ="N",
                CREATED_DATE =DateTime.Now
            });
            if (result)
            {
                var addFriend = friendRepo.GetOneFriend(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == userID && x.USER_ID == profileOwnerID));
              
                notifRepo.AddRow(new PB_NOTIFICATION
                {
                    RECEIVER_ID = addFriend.FRIEND_ID,
                    NOTIF_TYPE = "F",
                    SENDER_ID = addFriend.USER_ID,
                    CREATED_DATE = DateTime.Now,
                    SEEN ="N"
                   
                });
            }
            return result;
        }
        public bool AcceptFriend(int userID, int profileOwnerID)
        {
             var output =friendRepo.GetOneFriend(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == userID && x.USER_ID == profileOwnerID));
            output.REQUEST = "N";
            var result = friendRepo.UpdateRow(output);
            return result;
        }
        public bool RejectFriend(int userID, int profileOwnerID)
        {
            var friend = friendRepo.GetOneFriend(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == userID && x.USER_ID == profileOwnerID));
            var result = friendRepo.RemoveRow(friend);
            return result;
        }
    }
}
