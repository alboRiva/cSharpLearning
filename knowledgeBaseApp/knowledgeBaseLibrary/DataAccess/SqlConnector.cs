using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using knowledgeBaseLibrary.Models;
using Dapper;

namespace knowledgeBaseLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private List<Post> _repository;
        private readonly string _connectionString;

        public SqlConnector(string connectionString)
        {
            _connectionString = connectionString;
            LoadRepository();
        }
        public void AddOrUpdatePost(Post submittedPost, bool forceSaveIfInConflict = false)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                //Loads repository of posts in memory
                LoadRepository();

                //checks if the submitted post is new or the user wants to edit an existing one
                bool newPost = submittedPost.Id.Equals(Guid.Empty) &&
                               submittedPost.LastModifiedTime.Equals(DateTime.MinValue);

                if (newPost)
                {
                    if (_repository.Select(t => t.Title).Contains(submittedPost.Title))
                    {
                        throw new Exceptions.TitleAlreadyPresentInDBException("The title is already present in the database");
                    }
                    Post post = new Post(Guid.NewGuid(), submittedPost.Author, submittedPost.Title, submittedPost.Description, DateTime.UtcNow);
                    connection.Execute("dbo.Posts_AddRecord", SetDynamicParameters(post),
                        commandType: CommandType.StoredProcedure);
                }
                else
                {
                    //Check if submittedPost is effectively the last modified - if so, add it to the db 
                    if (!forceSaveIfInConflict &&
                        DateTime.Compare(GetPostFromRepo(submittedPost.Id).LastModifiedTime,
                            submittedPost.LastModifiedTime) > 0)
                        throw new Exceptions.ModifiedByOtherUserException($"The status of the element was changed by some other user after the read");

                    //update lastmodified
                    submittedPost.LastModifiedTime = DateTime.UtcNow;
                    //TODO: update tags
                    connection.Execute("dbo.Posts_UpdateRecord", SetDynamicParameters(submittedPost),
                        commandType: CommandType.StoredProcedure);

                }
               
            }
        }

        public void DeletePost(Post post)
        {
            //Delete from db
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Id", post.Id);
                connection.Execute("dbo.Posts_DeletePost", p, commandType: CommandType.StoredProcedure);
            }
            //Reload _repository
            LoadRepository();
        }

        public Post GetPost(Guid id)
        {
            {
                LoadRepository();
                foreach (var post in _repository)
                {
                    if (post.Id.Equals(id))
                        return post;
                }

                return null;
            }
        }

        public IEnumerable<Post> GetPostList(IEnumerable<string> tags, int pageNumber = 0, int itemsPerPage = int.MaxValue)
        {
            //LoadRepository();

            if (tags == null || !tags.Any())
                return _repository.Skip(pageNumber * itemsPerPage).Take(itemsPerPage);
            //Return all the posts which contain at least one tag
            return _repository.Where(post => {
                return post.Tags.Any(t => tags.Any(tt => String.Compare(t, tt, StringComparison.OrdinalIgnoreCase) == 0));
            }).Skip(pageNumber * itemsPerPage).Take(itemsPerPage);
        }

        public void PopulateDb()
        {
            //without anonymous obj
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                
                var parameters = new List<DynamicParameters>();

                for (int i = 0; i < 2000; i++)
                {
                    //Generate values
                    var guid = Guid.NewGuid();
                    string author = Environment.UserName;
                    string title = Utilities.LoremIpsum(10, 25, 1, 2, 1);
                    title = title + i;
                    string description = Utilities.LoremIpsum(100, 250, 10, 30, 2);
                    DateTime lastModified = new DateTime();
                    lastModified = DateTime.UtcNow;
                    //var tags = Utilities.GetTagsListFromString(title + description);
                    //TODO: fix too many parameters error (cmdSql.Parameters.Clear())
                    var tags = Utilities.GetTagsListFromString(title);

                    var p = new DynamicParameters();
                    //TODO: anonymous object
                    p.Add("@Id", guid);
                    p.Add("@Author", author);
                    p.Add("@Title", title);
                    p.Add("@Description", description);
                    p.Add("@LastModificationTime", lastModified);
                    p.Add("@Tags", "tag1 tag2 tag3 tag4");

                    parameters.Add(p);
                }

                connection.Execute("dbo.Posts_Populate", parameters, commandType: CommandType.StoredProcedure);
                    
                

            }
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //Generate values
            //        var guid = new Guid();
            //        string author = Utilities.LoremIpsum(2, 2, 1, 1, 1);
            //        string title = Utilities.LoremIpsum(10, 25, 1, 2, 1);
            //        string description = Utilities.LoremIpsum(100, 250, 10, 30, 2);
            //        DateTime  lastModified = new DateTime();
            //        lastModified = DateTime.UtcNow;
            //        //var tags = Utilities.GetTagsListFromString(title + description);
            //        var tags = "tags try";
            //        //Insert values in Db
            //        connection.Execute("dbo.Posts_Populate",
            //            new
            //            {
            //                guid,                          
            //                title,
            //                description,
            //                author,
            //                lastModified,
            //                tags,
            //            },
            //            commandType: CommandType.StoredProcedure);
            //    }

            //}
        }

        private DynamicParameters SetDynamicParameters(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@Id", post.Id);
            p.Add("@Author", post.Author);
            p.Add("@Title", post.Title);
            p.Add("@Description", post.Description);
            p.Add("@LastModificationTime", post.LastModifiedTime);
            //TODO: fix to p.add("@Tags", post.Tags);
            p.Add("@Tags", "tag1 tag2 tag3 tag4");
            return p;
        }
        private void LoadRepository()
        {
            //PopulateDb();

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                _repository = new List<Post>();
                var postList = connection.Query<Post>("dbo.Posts_GetAllPosts", commandType: CommandType.StoredProcedure).ToList();
                _repository.AddRange(postList);
            }
        }

        public Post GetPostFromRepo(Guid id)
        {
            foreach (var post in _repository)
            {
                if (post.Id.Equals(id))
                    return post;
            }

            return null;
        }
    }
}
