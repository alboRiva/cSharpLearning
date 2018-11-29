using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using knowledgeBaseLibrary.Models;

namespace knowledgeBaseLibrary.DataAccess
{
    public interface IDataConnection
    {

        void AddOrUpdatePost(Post sumbittedPost, bool forceSaveIfInConflict = false);

        void DeletePost(Post post);

        Post GetPost(Guid id);

        IEnumerable<Post> GetPostList(IEnumerable<string> tags, int pageNumber = 0, int itemsPerPage = Int32.MaxValue);
        IEnumerable<Post> SearchPost(string text, bool ricercaEsatta);
        IEnumerable<Post> GetRepository();

        void InitializeRepository(IEnumerable<Post> rawPostList);


    }
}