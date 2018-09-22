using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public class SqlConnector : IDataConnection
    {
        //TODO: implement
        /// <summary>
        /// Saves a Post to the database
        /// </summary>
        /// <param name="submittedPost"></param>
        /// <returns></returns>
        public Post CreatePost(Post submittedPost)
        {
           
            return submittedPost;
        }
    }
}
