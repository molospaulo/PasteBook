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
        GenericDataAccess<PB_USER> generic = new GenericDataAccess<PB_USER>();
        public IEnumerable<PB_USER> GetListOfUser(int id)
        {
            return generic.RetrieveListWithCondition( x => x.ID.Equals(id),x => x.PB_REF_COUNTRY,x => x.PB_POSTS);
        }
        public PB_USER GetUser(int id)
        {
            return generic.GetOneRecord(x => x.ID.Equals(id), x => x.PB_REF_COUNTRY,x => x.PB_POSTS);
        }
        public bool checkIfExist(int id)
        {
            return generic.CheckIfExist(x => x.ID.Equals(id));
        }
    }
}
