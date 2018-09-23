using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary.DataAccessManager
{
    class TextConnector : IDataConnection
    {
        public Post CreatePost(Post submittedPost)
        {
            //store the info in the same spot - always configurated in App.config
            //I need to read the file in order to find the ID
            //Load Text file
            //Convert to List<Post>
            //Find max ID
            //Add record with max ID + 1 to list<Post>
            //Convert Post to list<strings>
            //Save list<string> to text file
            return submittedPost;
        }
    }
}
