using System.Collections.Generic;
using knowledgeBaseLibrary.Models;

namespace knowledgeBaseLibrary.DataAccess
{
    public interface IDataConnection
    {
        /// <summary>
        /// Allows different ways of storing data, based on the class implementing it
        /// </summary>
        /// <param name="sumbittedPost"></param>
        /// <returns></returns>

        //TODO: should it throw an Exception or a bool?
        void AddPost(Post sumbittedPost);
        IEnumerable<Post> GetPostList(IEnumerable<string> tags);
    }
}