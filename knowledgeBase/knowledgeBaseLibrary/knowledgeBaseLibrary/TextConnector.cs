using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public class TextConnector : IDataConnection
    {
        public Post CreatePost(Post submittedPost)
        {
            return submittedPost;
        }
    }
}
