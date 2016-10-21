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
        public List<PB_POSTS> GetListOfUser(int id)
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
            .OrderByDescending(x => x.CREATED_DATE).ToList();

        }
    }
}
