using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using knowledgeBaseLibrary.Models;
using Dapper;
using knowledgeBaseLibrary.Exceptions;
using System.Windows.Forms;

namespace knowledgeBaseLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private readonly string _connectionString;

        public SqlConnector(string connectionString)
        {
            _connectionString = connectionString;
            //PopulateDb(2000);
        }

        //TODO: fix DateTime problem with Sql on new post creation
        public void AddOrUpdatePost(Post submittedPost, bool forceSaveIfInConflict = false)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                //checks if the submitted post is new or the user wants to edit an existing one
                bool newPost = submittedPost.Id.Equals(Guid.Empty) &&
                               submittedPost.LastModifiedTime.Equals(DateTime.MinValue);
                string sqlCommand;
                Post post;
                if (newPost)
                {
                    post = new Post();
                    post.CopyData(submittedPost);
                    post.LastModifiedTime = DateTime.UtcNow;
                    sqlCommand = "dbo.Posts_AddRecord";
                }
                else
                {
                    //Check if submittedPost is effectively the last modified - if so, add it to the db 
                    if (!forceSaveIfInConflict)
                    {
                        var oldPost = GetPost(submittedPost.Id);
                        if (oldPost == null)
                            throw new Exceptions.ModifiedByOtherUserException(
                                $"The element was deleted by some other user after the read");

                        if (DateTime.Compare(GetPost(submittedPost.Id).LastModifiedTime,
                                submittedPost.LastModifiedTime) > 0)
                            throw new Exceptions.ModifiedByOtherUserException(
                                $"The status of the element was changed by some other user after the read");
                    }
                    post = submittedPost;
                    //update lastmodified  - important for concurrency 
                    post.LastModifiedTime = DateTime.UtcNow;
                    sqlCommand = "dbo.Posts_UpdateRecord";
                }

                try
                {
                    connection.Execute(sqlCommand, new
                        {
                            submittedPost.Id,
                            submittedPost.Author,
                            submittedPost.Title,
                            submittedPost.Description,
                            submittedPost.LastModifiedTime,
                    },
                        commandType: CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    if(ex.Number == 2627)
                        throw new TitleAlreadyPresentInDBException(ex.Message);
                    throw;
                }

            }
        }

        public void DeletePost(Post post)
        {
            //Delete from db
            var confirmResult = MessageBox.Show("Are you sure to delete this post?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Id", post.Id);
                connection.Execute("dbo.Posts_DeletePost", new {post.Id}, commandType: CommandType.StoredProcedure);
            }
        }

        public Post GetPost(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
                return connection.Query<Post>("dbo.Posts_GetPost",
                    new { id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<Post> GetPostList(IEnumerable<string> tags, int pageNumber = 0, int itemsPerPage = int.MaxValue)
        {
            if (tags == null)
                tags = Enumerable.Empty<string>();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tag", typeof(string));
            foreach (string tag in tags)
                dt.Rows.Add(tag);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                int skipRows = 0;
                if (itemsPerPage != int.MaxValue)
                    skipRows = (pageNumber * itemsPerPage);

                //TableValuesParameter Tags
                return connection.Query<Post>("dbo.Posts_GetPosts",
                        new { tags = dt.AsTableValuedParameter("dbo.Tags"), skipRows, takeRows = itemsPerPage },
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void PopulateDb(int numberOfRecords)
        {
            //without anonymous obj
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                
                for (int i = 0; i < numberOfRecords; i++)
                {
                    //Generate values
                    var guid = Guid.NewGuid();
                    string author = Environment.UserName;
                    string title = Utilities.LoremIpsum(10, 25, 1, 2, 1);
                    title = title + i;
                    string description = Utilities.LoremIpsum(100, 250, 10, 30, 2);
                    DateTime lastModified = new DateTime();
                    lastModified = DateTime.UtcNow;

                    connection.Execute("dbo.Posts_Populate", new
                    {
                        Id = guid,
                        Author = author,
                        Title = title,
                        Description = description,
                        LastModifiedTime = lastModified,
                    }, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
