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
            PB_FRIENDS friend = new PB_FRIENDS();
            friend = genericDataAccess.GetOneRecord(x => (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID) || (x.FRIEND_ID == profileOwnerID && x.USER_ID == userID),x=>x.PB_USER,x=>x.PB_USER1);
            if (friend != null)
            {
                if (friend.PB_USER.ID == userID && friend.PB_USER1.ID == profileOwnerID && friend.REQUEST =="N")
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
        public bool AddFriend(int userID, int friendID)
        {
            return genericDataAccess.AddRow(new PB_FRIENDS {
                USER_ID = userID,
                FRIEND_ID = friendID,
                REQUEST ="Y",
                IsBLOCKED ="N",
                CREATED_DATE =DateTime.Now
            });
        }
        public bool AcceptFriend(int userID, int friendID)
        {
            return genericDataAccess.UpdateRow(new PB_FRIENDS
            {
                USER_ID = userID,
                FRIEND_ID = friendID,
                REQUEST = "N",
                IsBLOCKED = "N",
                CREATED_DATE = DateTime.Now
            });
        }
    }
}