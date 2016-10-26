﻿using PasteBookDataAccess;
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
        GenericDataAccess<PB_FRIENDS> genericDataAccess = new GenericDataAccess<PB_FRIENDS>();
        public List<PB_USER> GetUserFriends(int id)
        {
            List<PB_USER> listOfFriends = new List<PB_USER>();
         
            var output = genericDataAccess.RetrieveListWithCondition(x => (x.USER_ID == id || x.FRIEND_ID == id) && x.REQUEST == "N",x=>x.PB_USER1,x => x.PB_USER);
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
                friend = genericDataAccess.GetOneRecord(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID ==userID  && x.USER_ID == profileOwnerID), x => x.PB_USER, x => x.PB_USER1);
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
            var result = genericDataAccess.AddRow(new PB_FRIENDS {
                USER_ID = userID,
                FRIEND_ID = profileOwnerID,
                REQUEST ="Y",
                IsBLOCKED ="N",
                CREATED_DATE =DateTime.Now
            });
            if (result)
            {
                var addFriend = genericDataAccess.GetOneRecord(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == userID && x.USER_ID == profileOwnerID), x => x.PB_USER, x => x.PB_USER1);
                Notification notif = new Notification();
                notif.AddNotification(new PB_NOTIFICATION
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
             var output =genericDataAccess.GetOneRecord(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == userID && x.USER_ID == profileOwnerID), x => x.PB_USER, x => x.PB_USER1);
            var genericDataAccess1 = new GenericDataAccess<PB_NOTIFICATION>();
            output.REQUEST = "N";
            var result = genericDataAccess.UpdateRow(output);
            if (result)
            {
                var notif = genericDataAccess1.GetOneRecord(x => (x.SENDER_ID == userID || x.SENDER_ID == profileOwnerID) && (x.RECEIVER_ID == userID || x.RECEIVER_ID == profileOwnerID) && x.NOTIF_TYPE == "F" && x.SEEN == "N");
                notif.SEEN = "Y";
                genericDataAccess1.UpdateRow(notif);
            }
            return result;
        }
        public bool RejectFriend(int userID, int profileOwnerID)
        {
            Notification notif = new Notification();
            var genericDataAccess1 = new GenericDataAccess<PB_NOTIFICATION>();
            var result = genericDataAccess.RemoveRow(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == userID && x.USER_ID == profileOwnerID));
            if (result)
            {
                var notification = genericDataAccess1.GetOneRecord(x => (x.SENDER_ID == userID || x.SENDER_ID == profileOwnerID) && (x.RECEIVER_ID == userID || x.RECEIVER_ID == profileOwnerID) && x.NOTIF_TYPE == "F");
                notification.SEEN = "Y";
                genericDataAccess1.UpdateRow(notification);
            }
            return result;
        }
    }
}
