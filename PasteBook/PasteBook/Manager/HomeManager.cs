using PasteBookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class HomeManager
    {
        PasteBookManager manager = new PasteBookManager();
        MapperUI map = new MapperUI();



        public UsersPartialDetailsUI GetUserPartialDetails(int id)
        {
            var output = manager.GetUserPartialDetails(id);
            return map.MapUserPartialDetails(output);

        }
        public List<UsersPartialDetailsUI> GetUserFriends(int id)
        {
            List<UsersPartialDetailsUI> listOfFriends = new List<UsersPartialDetailsUI>();
            var output = manager.GetListOfFriends(id);
            foreach (var item in output)
            {
                listOfFriends.Add(map.MapUserPartialDetails(item));
            }
            return listOfFriends;
        }

        public int GetUserID(string emailAddress)
        {
            return manager.GetUserID(emailAddress);
        }
        public List<PostsModel> GetListOfPosts(int id)
        {
            List<PostsModel> listOfPosts = new List<PostsModel>();
            var result = manager.GetListOfPost(id);

            foreach (var item in result)
            {
                listOfPosts.Add(map.MapPosts(item));
            }

            return listOfPosts;
        }
        public bool AddOrDeleteLike(int ID, int PostID, out string status)
        {
            if (manager.checkLikeIfExist(PostID, ID))
            {
                status = "deletelike";
                return manager.DeleteLike(PostID, ID);
            }
            else
            {
                status = "addlike";
                return manager.AddLike(PostID, ID);
            }
        }
        public bool AddPost(int ID, string post, int profileOwnerID)
        {
            return manager.AddPost(ID, post, profileOwnerID);
        }
    }
  

}