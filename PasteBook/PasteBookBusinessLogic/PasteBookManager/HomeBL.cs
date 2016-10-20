
using PasteBookDataAccess;
using PasteBookDataAccess.Manager;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class HomeBL
    {
        HomeDataAccess manager = new HomeDataAccess();
        public PB_USER GetUserPartialDetails(int id)
        {
            var output = manager.GetUserPartialDetails(id);
            return output;

        }
        public List<PB_USER> GetUserFriends(int id)
        {
            List<PB_USER> listOfFriends = new List<PB_USER>();
            var output = manager.GetListOfFriends(id);
            foreach (var item in output)
            {
                listOfFriends.Add(item);
            }
            return listOfFriends;
        }

        public PB_USER GetUserProfileDetails(int id)
        {
            return manager.GetUserProfileDetails(id);
        }



        public int GetUserID(string emailAddress)
        {
            return manager.GetUserID(emailAddress);
        }
        public List<GetNewsFeed_Result> GetListOfPosts(int id)
        {
            List<GetNewsFeed_Result> listOfPosts = new List<GetNewsFeed_Result>();
            var result = manager.GetListOfPost(id);

            foreach (var item in result)
            {
                listOfPosts.Add(item);
            }

            return listOfPosts;
        }
        public List<PB_POSTS> GetlistOfPostsTimeline(int id)
        {
            List<PB_POSTS> listOfPosts = new List<PB_POSTS>();
            var result = manager.GetListOfPostTimeline(id);

            foreach (var item in result)
            {
                listOfPosts.Add(item);
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

        public string IsFriend(int id, int profileOwnerID)
        {
            PB_FRIENDS friend = new PB_FRIENDS();
            friend = manager.IsFriend(id, profileOwnerID);
            if (friend != null)
            {
                if (friend.REQUEST == "N")
                {
                    return "friend";
                }
                else
                {
                    return "request";
                }
            }
            else
            {
                return "notfriend";
            }

        }
        public List<PB_USER> SearchListOfUsers(string keyword)
        {
            List<PB_USER> users = new List<PB_USER>();
            var result = manager.GetlistOfUsers(keyword);
            foreach (var item in result)
            {
                users.Add(item);
            }
            return users;
        }

    }
}
