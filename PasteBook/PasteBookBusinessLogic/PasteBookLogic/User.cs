using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasteBookDataAccess;
using PasteBookModel;

namespace PasteBookBusinessLogic
{
    public class User
    {
        GenericDataAccess<PB_USER> genericDataAccess = new GenericDataAccess<PB_USER>();
        public IEnumerable<PB_USER> GetListOfUser(int id)
        {
            return genericDataAccess.RetrieveListWithCondition( x => x.ID.Equals(id),x => x.PB_REF_COUNTRY,x => x.PB_POSTS);
        }
        public PB_USER GetUser(int id)
        {
            return genericDataAccess.GetOneRecord(x => x.ID.Equals(id), x => x.PB_REF_COUNTRY,x => x.PB_POSTS);
        }
        public bool checkIfExist(int id)
        {
            return genericDataAccess.CheckIfExist(x => x.ID.Equals(id));
        }
        public List<PB_USER> SearchListOfUsers(string keyword)
        {
            List<PB_USER> users = new List<PB_USER>();
            var result = genericDataAccess.RetrieveListWithCondition(x => x.FIRST_NAME == keyword || x.LAST_NAME == keyword);
            foreach (var item in result)
            {
                users.Add(item);
            }
            return users;
        }
        public int GetUserID(string emailAddress)
        {
           var result = genericDataAccess.GetOneRecord(x => x.EMAIL_ADDRESS == emailAddress);
            return result.ID;
        }
        public bool UpdateImage(byte[] image, int id)
        {
            var user = genericDataAccess.GetOneRecord(x=>x.ID == id);
            user.PROFILE_PIC = image;
            var result = genericDataAccess.UpdateRow(user);
            return result;
        }
    }
}
