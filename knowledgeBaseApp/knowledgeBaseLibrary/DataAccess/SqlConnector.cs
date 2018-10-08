using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using knowledgeBaseLibrary.Models;

namespace knowledgeBaseLibrary.DataAccess
{
    class SqlConnector : IDataConnection
    {
        public void AddPost(Post sumbittedPost)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostList(IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }
    }
}
