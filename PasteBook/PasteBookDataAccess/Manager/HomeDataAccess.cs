﻿using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class HomeDataAccess
    {
        Mapper map = new Mapper();
        public PB_USER GetUserPartialDetails(int id)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.ID == id).Select(x => x).Single();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new PB_USER() { };
            }
        }
        public PB_USER GetUserProfileDetails(int id)
        {
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.ID == id).Select(x => x).Single();
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

        public List<GetNewsFeed_Result> GetListOfPost(int UserID)
        {
            List<GetNewsFeed_Result> listOfPosts = new List<GetNewsFeed_Result>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    SqlParameter[] parameters = new SqlParameter[]
                     {
                        new SqlParameter("@ID", UserID)
                     };
                    var result = context.Database.SqlQuery<GetNewsFeed_Result>("GetNewsFeed @UserID = @ID", parameters).OrderByDescending(x => x.CREATED_DATE);
                    foreach (var item in result)
                    {
                        listOfPosts.Add(item);
                    }
                }

            }
            catch (Exception e)
            {
                return new List<GetNewsFeed_Result>() { };
            }
            return listOfPosts;
        }
        public List<PB_POSTS> GetListOfPostTimeline(int UserID)
        {
            List<PB_POSTS> listOfPosts = new List<PB_POSTS>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_POSTS.Where(x => (x.PROFILE_OWNER_ID == UserID && x.POSTER_ID == UserID) || (x.PROFILE_OWNER_ID == UserID)).OrderByDescending(x => x.CREATED_DATE).ToList();
                    foreach (var item in result)
                    {
                        listOfPosts.Add(item);
                    }

                }
            }
            catch (Exception e)
            {
                return new List<PB_POSTS>() { };
            }
            return listOfPosts;
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
        public List<PB_USER> GetListOfFriends(int userID)
        {
            List<PB_USER> listOfFriends = new List<PB_USER>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_FRIENDS.Where(x => x.USER_ID == userID && x.REQUEST == "N").ToList();

                    foreach (var item in result)
                    {
                        listOfFriends.Add(item.PB_USER);
                    }
                }
            }
            catch (Exception e)
            {
                return new List<PB_USER>() { };
            }
            return listOfFriends;
        }

        public PB_FRIENDS IsFriend(int userID, int ProfileOwnerID)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var output = context.PB_FRIENDS.Where(x => x.FRIEND_ID == ProfileOwnerID && x.USER_ID == userID && x.IsBLOCKED == "N").Select(x => x).Single();
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
            List<PB_USER> listOfUsers = new List<PB_USER>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.FIRST_NAME == keyword || x.LAST_NAME == keyword).Select(x => x).ToList();
                    foreach (var item in result)
                    {
                        listOfUsers.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                return listOfUsers;
            }
            return listOfUsers;
        }
    }
}
