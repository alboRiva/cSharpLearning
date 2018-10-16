using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using knowledgeBaseLibrary.Models;

namespace knowledgeBaseLibrary.DataAccess
{
    public interface IDataConnection
    {

        void AddOrUpdatePost(Post sumbittedPost);

        void DeletePost(Post post);

        Post GetPost(Guid id);

        IEnumerable<Post> GetPostList(IEnumerable<string> tags);

    }
}