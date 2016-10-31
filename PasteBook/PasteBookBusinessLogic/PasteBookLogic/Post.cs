using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class Post
    {

        PostRepository postRepo = new PostRepository();
        public bool AddPost(int ID, string post, int profileOwnerID)
        {
            return postRepo.AddRow(new PB_POSTS
            {
                POSTER_ID = ID,
                CONTENT = post,
                PROFILE_OWNER_ID = profileOwnerID,
                CREATED_DATE = DateTime.Now
                
            });
        }
        public List<PB_POSTS> GetListOfPostNewsFeed(int userID)
        {
            Friend friend = new Friend();
             var friends = friend.GetUserFriends(userID);
            List<int> listOfUsersID = new List<int>();
            foreach (var item in friends)
            {
                listOfUsersID.Add(item.ID);
            }
            listOfUsersID.Add(userID);
           return postRepo.GetListOfNewsFeedPosts(listOfUsersID);

        }


    }
}
