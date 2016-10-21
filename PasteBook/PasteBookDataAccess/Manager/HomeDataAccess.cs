using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class HomeDataAccess
    {
        Mapper map = new Mapper();
        public PB_USER GetUserProfileDetails(int id)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.ID == id).Select(x => x).SingleOrDefault();
                    var country = result.PB_REF_COUNTRY.COUNTRY;
                    return result;
                }
            }
            catch (Exception e)
            {
                return new PB_USER() { };
            }
        }





        public int GetUserID(string emailAddress)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.EMAIL_ADDRESS == emailAddress).Select(x => x.ID).Single();
                    return result;
                }

            }
            catch (Exception e)
            {
                return 0;
            }

        }

     
       
        public bool checkLikeIfExist(int postID, int userLikeID)
        {
            bool output = false;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    output = context.PB_LIKES.Any(x => x.POST_ID == postID && x.LIKED_BY == userLikeID);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return output;
        }
        public bool AddLike(int postID, int userLikeID)
        {
            bool output = false;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    PB_LIKES like = new PB_LIKES();
                    like.POST_ID = postID;
                    like.LIKED_BY = userLikeID;
                    context.PB_LIKES.Add(like);
                    var result = context.SaveChanges();
                    output = result != 0 ? true : false;

                }
            }
            catch (Exception e)
            {
                return false;
            }
            return output;
        }

        public bool DeleteLike(int postID, int userLikeID)
        {
            bool output = false;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var entry = context.PB_LIKES.Where(x => x.POST_ID == postID && x.LIKED_BY == userLikeID).Select(x => x).Single();

                    if (entry != null)
                    {
                        context.PB_LIKES.Remove(entry);
                        var result = context.SaveChanges();
                        output = result != 0 ? true : false;

                    }

                }
            }
            catch (Exception e)
            {
                return false;
            }
            return output;
        }



        public bool IsLiked(int userID, int postID)
        {
            bool output = false;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    output = context.PB_LIKES.Any(x => x.POST_ID == postID && x.LIKED_BY == userID);
                    return output;
                }

            }
            catch (Exception e)
            {
                return output;
            }
        }
        public bool AddPost(int posterID, string post, int profileOwnerID)
        {
            bool output = false;

            try
            {
                using (var context = new PasteBookEntities())
                {
                    PB_POSTS newPost = new PB_POSTS();
                    newPost.CONTENT = post;
                    newPost.POSTER_ID = posterID;
                    newPost.PROFILE_OWNER_ID = profileOwnerID;
                    newPost.CREATED_DATE = DateTime.Now;

                    context.PB_POSTS.Add(newPost);
                    var result = context.SaveChanges();
                    output = result != 0 ? true : false;
                }
            }
            catch (Exception e)
            {
                return false;

            }

            return output;
        }
        public List<PB_FRIENDS> GetListOfFriends(int userID)
        {
            List<PB_FRIENDS> listOfFriends = new List<PB_FRIENDS>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_FRIENDS.Include("PB_USER").Include("PB_USER1").Where(x => (x.USER_ID == userID || x.FRIEND_ID == userID) && x.REQUEST == "N").ToList();
                    
                    foreach (var item in result)
                    {
                        listOfFriends.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                return new List<PB_FRIENDS>() { };
            }
            return listOfFriends;
        }

        public PB_FRIENDS IsFriend(int userID, int ProfileOwnerID)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var output = context.PB_FRIENDS.Where(x => ((x.FRIEND_ID == ProfileOwnerID && x.USER_ID == userID)|| (x.FRIEND_ID == ProfileOwnerID && x.USER_ID == userID)) && x.IsBLOCKED == "N").Select(x => x).Single();
                    return output;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<PB_USER> GetlistOfUsers(string keyword)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.FIRST_NAME == keyword || x.LAST_NAME == keyword).Select(x => x).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<PB_USER>() { };
            }
          
        }
        public List<PB_COMMENTS> GetListOfComments(int postID)
        {
            try
            {
                using(var context = new PasteBookEntities())
                {
                    var result = context.PB_COMMENTS.Include("PB_USER").Where(x => x.POST_ID == postID).Select(x => x).ToList();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }
        public bool IsUserLiked(int userID, int postID)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_LIKES.Any(x => x.LIKED_BY == userID && x.POST_ID == postID);
                    return result;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<PB_LIKES> Likers(int postID)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_LIKES.Where(x => x.POST_ID == postID).ToList();
                    return result;
                }
            }
            catch
            {
                return new List<PB_LIKES>() { } ;
            }
        }
        public bool AddComment(PB_COMMENTS comment)
        {
            bool output = false;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    context.PB_COMMENTS.Add(comment);
                    var result = context.SaveChanges();
                    output = result != 0 ? true : false;
                   
                }
            }
            catch (Exception e)
            {
                return output;
            }
            return output;
        }
    }
}
