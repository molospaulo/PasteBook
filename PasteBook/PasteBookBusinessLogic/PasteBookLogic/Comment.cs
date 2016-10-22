using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic { 
    public class Comment
    {
    GenericDataAccess<PB_COMMENTS> genericDataAccess = new GenericDataAccess<PB_COMMENTS>();
        public bool AddComment(int postID, int posterID, string content)
        {
            return genericDataAccess.AddRow(new PB_COMMENTS
            {
                POST_ID = postID,
                POSTER_ID = posterID,
                CONTENT = content,
                DATE_CREATED = DateTime.Now

            });
        }
    }
}
