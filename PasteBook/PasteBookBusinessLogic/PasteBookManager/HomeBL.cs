
using PasteBookDataAccess;
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
            var output = manager.GetUserProfileDetails(id);
            return output;

        }
        public List<PB_USER> GetUserFriends(int id)
        {
            List<PB_USER> listOfFriends = new List<PB_USER>();
            var output = manager.GetListOfFriends(id);
            foreach (var item in output)
            {

                if(item.PB_USER.ID == id)
                {
                    listOfFriends.Add(item.PB_USER1);
                }else
                {
                    listOfFriends.Add(item.PB_USER);
                }
               
            }
            return listOfFriends;
        }

        public PB_USER GetUserProfileDetails(int id)
        {
            var result = manager.GetUserProfileDetails(id);
             var country =result.PB_REF_COUNTRY.COUNTRY ;
            return manager.GetUserProfileDetails(id);
        }



        public int GetUserID(string emailAddress)
        {
            return manager.GetUserID(emailAddress);
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

        public List<NewsFeedViewModel> NewsFeedPostsWithComments(int userID,List<PB_POSTS> result)
        {
            List<NewsFeedViewModel> listOfNewsFeed = new List<NewsFeedViewModel>() { };
            
            foreach (var item in result)
            {
                listOfNewsFeed.Add(new NewsFeedViewModel()
                {
                    ID = item.ID,
                    CREATED_DATE = item.CREATED_DATE,
                    CONTENT = item.CONTENT,
                    PROFILE_OWNER_ID = item.PROFILE_OWNER_ID,
                    POSTER_ID = item.POSTER_ID,
                    PB_USER = manager.GetUserProfileDetails(item.POSTER_ID),
                    IsLike = manager.IsLiked(userID, item.ID),
                    CountOfLikes = manager.Likers(item.ID),
                    ListOfComments = manager.GetListOfComments(item.ID)

                });
            }
            return listOfNewsFeed;
        }
        
       public bool AddComment(int postID, int posterID, string content)
        {
            return manager.AddComment(new PB_COMMENTS
            {
                POST_ID = postID,
                POSTER_ID = posterID,
                CONTENT = content,
                DATE_CREATED = DateTime.Now

            });
        }
    }
}
