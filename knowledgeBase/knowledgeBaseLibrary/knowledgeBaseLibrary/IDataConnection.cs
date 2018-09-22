using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public interface IDataConnection
    {
        /// <summary>
        /// Allows multiple ways of storing data, based on the class implementing it
        /// </summary>
        /// <param name="submittedPost"></param>
        /// <returns></returns>
        Post CreatePost(Post submittedPost);
    }
}
