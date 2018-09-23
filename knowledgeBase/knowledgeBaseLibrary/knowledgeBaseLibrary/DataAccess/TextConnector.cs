namespace knowledgeBaseLibrary.Models
{
    public class TextConnector : IDataConnection
    {
        public Post CreatePost(Post submittedPost)
        {
            return submittedPost;
        }
    }
}
