using PasteBookDataAccess.Entities;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
   public class PasteBookManager
    {
        Mapper map = new Mapper();
        /// <summary>
        /// Retrieve the list of countries in the database
        /// </summary>
        /// <returns></returns>
        public List<Country> GetListOfcountry()
        {
            List<Country> listOfCountry = new List<Country>() ;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_REF_COUNTRY.ToList();
                    foreach (var item in result)
                    {
                        listOfCountry.Add(new Country { CountryID = item.ID, Name = item.COUNTRY });
                    }
                }
            }
            catch (Exception e)
            {
                return new List<Country>() { };
            }

            return listOfCountry;
        }



    /// <summary>
    /// Save User in the database
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
        public bool SaveUser(UserDetails user)
        {
            bool returnValue = false;

            try
            {
                using (var context = new PasteBookEntities())
                {
                   
                     context.PB_USER.Add(map.MapUser(user));
                    var result = context.SaveChanges();
                    returnValue = result != 0 ? true : false;
                  
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return returnValue;
        }
        public UserPartialDetails GetUserPartialDetails(int id)
        {
            try
            {
                using(var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Where(x => x.ID == id).Select(x => x).Single();
                    return new UserPartialDetails
                    {
                        ID=result.ID,
                        UserName = result.USER_NAME,
                        FirstName = result.FIRST_NAME,
                        LastName =result.LAST_NAME,
                        ProfilePic =result.PROFILE_PIC
                    };
                }
            }
            catch (Exception e)
            {
                return new UserPartialDetails { };
            }
        }




        public bool CheckUsernameIfExisting(string username)
        {
           
            try{
                using(var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Any(x => x.USER_NAME == username);
                    return result;
                }
                }catch(Exception e)
            {
                return false;
            }
        }
        public bool CheckEmailIfExisting(string email)
        {

            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_USER.Any(x => x.EMAIL_ADDRESS == email);
                    return result;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public UserCredentials Login(string emailAddress)
        {
            try
            {
                if (CheckEmailIfExisting(emailAddress))
                {
                    using (var context = new PasteBookEntities())
                    {
                        var result = context.PB_USER.Where(x => x.EMAIL_ADDRESS == emailAddress).Single();

                        return new UserCredentials { EmailAddress = result.EMAIL_ADDRESS, PasswordHash = result.PASSWORD, Salt = result.SALT };
                    }

                }else
                {
                    return null;
                }
            } catch(Exception e)
            {
                return null;
            }
        }
        
        public int GetUserID(string emailAddress)
        {

            try
            {
                    using(var context = new PasteBookEntities())
                    {
                        var result = context.PB_USER.Where(x => x.EMAIL_ADDRESS == emailAddress).Select(x => x.ID).Single();
                        return result;
                    }
            
            }catch(Exception e)
            {
                return 0;
            }

        }

        public List<Post> GetListOfPost(int UserID)
        {
            List<Post> listOfPosts = new List<Post>();
            try
            {
                using(var context = new PasteBookEntities())
                {
                    //var result = context.PB_POSTS.Where(x => x.PROFILE_OWNER_ID == UserID).OrderByDescending(x => x.CREATED_DATE).ToList();
                    //foreach (var item in result)
                    //{
                    //    listOfPosts.Add(map.MapPost(item));
                    //}
                    SqlParameter[] parameters = new SqlParameter[]
                     {
                        new SqlParameter("@ID", UserID)
                     };
                    var result = context.Database.SqlQuery<GetNewsFeed_Result>("GetNewsFeed @UserID = @ID", parameters).OrderByDescending(x=>x.CREATED_DATE);
                    foreach (var item in result)
                    {
                        listOfPosts.Add(new Post {
                              ID = item.ID,
                              Poster = item.POSTER_ID,
                              Content =item.CONTENT,
                              ProfileOwnerID = item.PROFILE_OWNER_ID,
                              countOfLikes =item.countOfLikes.Value,
                              DateCreated =item.CREATED_DATE,
                              FirstName = item.FIRST_NAME,
                              LastName = item.LAST_NAME
                              
                          });
                    }


                }
            }
            catch (Exception e)
            {
                return new List<Post> (){ };
            }
            return listOfPosts;
        }
        public List<Post> GetListOfPostTimeline(int UserID)
        {
            List<Post> listOfPosts = new List<Post>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    var result = context.PB_POSTS.Where(x => x.PROFILE_OWNER_ID == UserID).OrderByDescending(x => x.CREATED_DATE).ToList();
                    foreach (var item in result)
                    {
                        listOfPosts.Add(map.MapPost(item));
                    }

                }
            }
            catch (Exception e)
            {
                return new List<Post>() { };
            }
            return listOfPosts;
        }
        public bool checkLikeIfExist(int postID, int userLikeID)
        {
            bool output = false;
            try
            {
              using( var context = new PasteBookEntities())
                {
                    output = context.PB_LIKES.Any(x => x.POST_ID == postID && x.LIKED_BY == userLikeID);
                }
            }
            catch(Exception e)
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
            }catch(Exception e)
            {
                return false;
            }
            return output;
        }

        public bool DeleteLike(int postID,int userLikeID)
        {
            bool output = false;
            try
            {
                using(var context = new PasteBookEntities())
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

        public bool AddPost(int posterID,string post, int profileOwnerID)
        {
            bool output = false;

            try
            {
                using(var context = new PasteBookEntities())
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
            }catch(Exception e)
            {
                return false;

            }

            return output;
        }
        public List<UserPartialDetails> GetListOfFriends(int userID)
        {
            List<UserPartialDetails> listOfFriends = new List<UserPartialDetails>();
            try
            {
                using(var context = new PasteBookEntities())
                {
                    var result = context.PB_FRIENDS.Where(x => x.USER_ID == userID && x.REQUEST == "N").ToList();

                    foreach (var item in result)
                    {
                        listOfFriends.Add(new UserPartialDetails
                        {
                            ID = item.PB_USER.ID,
                            FirstName =item.PB_USER.FIRST_NAME,
                            LastName=item.PB_USER.LAST_NAME,
                            UserName=item.PB_USER.USER_NAME,
                            ProfilePic=item.PB_USER.PROFILE_PIC
                        });
                    }
                }
            }catch(Exception e)
            {
                return new List<UserPartialDetails>() { };
            }
            return listOfFriends;
        }

    }
}
