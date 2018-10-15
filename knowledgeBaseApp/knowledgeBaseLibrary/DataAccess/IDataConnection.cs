using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
        //TODO: should it throw an Exception or a bool? EXCEPTION
        void AddOrUpdatePost(Post sumbittedPost);

        void DeletePost(Post post);

        Post GetPost(Guid id);

        IEnumerable<Post> GetPostList(IEnumerable<string> tags);

    }
}