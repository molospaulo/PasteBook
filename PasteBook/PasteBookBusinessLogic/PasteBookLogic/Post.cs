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
       
        GenericDataAccess<PB_POSTS> generic = new GenericDataAccess<PB_POSTS>();
        public List<PB_POSTS> GetListOfPost(int id)
        {
            return generic.RetrieveListWithCondition(x => x.ID.Equals(id), x => x.PB_COMMENTS, x => x.PB_LIKES, x => x.PB_NOTIFICATION, x => x.PB_USER, x => x.PB_USER1);
        }
        public PB_POSTS GetPost(int id)
        {
            return generic.GetOneRecord(x => x.ID.Equals(id),x => x.PB_COMMENTS,x=>x.PB_LIKES,x=>x.PB_NOTIFICATION,x=>x.PB_USER,x=>x.PB_USER1);
        }
        public bool CheckIfExisting(int id)
        {
            return generic.CheckIfExist(x => x.ID.Equals(id));
        }
        public List<PB_POSTS> GetListOfPostTimeline(int UserID)
        {
            return generic.RetrieveListWithCondition(x => (x.PROFILE_OWNER_ID == UserID && x.POSTER_ID == UserID) || (x.PROFILE_OWNER_ID == UserID)
            , x => x.PB_COMMENTS, x => x.PB_LIKES, x => x.PB_NOTIFICATION, x => x.PB_USER, x => x.PB_USER1)
            .OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();

        }
        public bool AddPost(int ID, string post, int profileOwnerID)
        {
            return generic.AddRow(new PB_POSTS
            {
                POSTER_ID = ID,
                CONTENT = post,
                PROFILE_OWNER_ID = profileOwnerID,
                CREATED_DATE = DateTime.Now
                
            });
        }
        public List<PB_POSTS> GetListOfPostNewsFeed(int userID)
        {
            List<PB_POSTS> posts = new List<PB_POSTS>();
            Friend friend = new Friend();
            var result = friend.GetUserFriends(userID);
            foreach (var item in result)
            {
                var friendPosts = generic.RetrieveListWithCondition(x =>x.POSTER_ID == item.ID,x => x.PB_COMMENTS, x => x.PB_LIKES, x => x.PB_NOTIFICATION, x => x.PB_USER, x => x.PB_USER1);
                foreach (var item1 in friendPosts)
                {
                    posts.Add(item1);
                }
            }

            var myPosts = generic.RetrieveListWithCondition(x => x.POSTER_ID == userID, x => x.PB_COMMENTS, x => x.PB_LIKES, x => x.PB_NOTIFICATION, x => x.PB_USER, x => x.PB_USER1);
            foreach (var item in myPosts)
            {
                posts.Add(item);
            }
           var orderedPost = posts.OrderByDescending(x => x.CREATED_DATE).ToList();
            return orderedPost;
        }
        

    }
}
