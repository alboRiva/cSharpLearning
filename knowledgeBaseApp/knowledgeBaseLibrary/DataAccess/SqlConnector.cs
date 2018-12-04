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
using rm.Trie;
using System.Diagnostics;

namespace knowledgeBaseLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private readonly string _connectionString;
        private readonly Dictionary<Guid,Post> _repository = new Dictionary<Guid, Post>();

        public SqlConnector(string connectionString)
        {
            _connectionString = connectionString;
            //--------DB Population values
            //Title -> 10-25 words, 1 paragraph and 1 sentence
            //Description -> 200-350 words, 2-3 sentences and 2 paragraphs - Average total of words 1125
            //PopulateDb(5000);
        }

        /// <summary>
        /// Update or add a post (if new) - forceSaveIfInConflict=true forces write
        /// ignoring concurrency (post edit by other user during editing)
        /// </summary>
        /// <param name="submittedPost"></param>
        /// <param name="forceSaveIfInConflict"></param>
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
                    //TODO: gestione concorrenza in _repository                    
                    post = submittedPost;
                    //update lastmodified  - important for concurrency 
                    post.LastModifiedTime = DateTime.UtcNow;
                    sqlCommand = "dbo.Posts_UpdateRecord";
                    
                }

                try
                {
                    connection.Execute(sqlCommand, new
                        {
                            post.Id,
                            post.Author,
                            post.Title,
                            post.Description,
                            post.LastModifiedTime,
                    },
                        commandType: CommandType.StoredProcedure);
                    
                    //Update _repository based if new or updated post
                    if (_repository.ContainsKey(submittedPost.Id))
                    {
                        _repository.Remove(submittedPost.Id);
                    }
                    Utilities.GenerateTrie(submittedPost);
                    _repository.Add(submittedPost.Id, submittedPost);
                    
                }
                catch (SqlException ex)
                {
                    if(ex.Number == 2627)
                        throw new TitleAlreadyPresentInDBException(ex.Message);
                    throw;
                }

            }
        }

        /// <summary>
        /// Delete a post from db by Id
        /// </summary>
        /// <param name="post"></param>
        public void DeletePost(Post post)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this post?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                using (IDbConnection connection = new SqlConnection(_connectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", post.Id);
                    connection.Execute("dbo.Posts_DeletePost", new {post.Id}, commandType: CommandType.StoredProcedure);
                    //Delete post from memory _repository too
                    _repository.Remove(post.Id);
                }
        }

        /// <summary>
        /// Retrive a single post from db by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post GetPost(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
                return connection.Query<Post>("dbo.Posts_GetPost",
                    new { id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        /// <summary>
        /// Returns IEnumerable<Post> after query based on tags
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="pageNumber"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        public IEnumerable<Post> GetPostList(IEnumerable<string> tags, int pageNumber = 0, int itemsPerPage = int.MaxValue)
        {
            //TODO: GetPostList's only use is now to return the full db - TO BE REMOVED
            
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

                //TableValuesParameter SearchTrie
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
                    string title = Utilities.LoremIpsum(10, 25, 1, 1, 1);
                    title = title + i;
                    string description = Utilities.LoremIpsum(200, 350, 2, 3, 2);
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

        /// <summary>
        /// Retrieves posts containing same prefix as search input text - input text 
        /// preprocessed in SearchPost(string text)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public IEnumerable<Post> SearchPost(string text, bool ricercaEsatta = false)
        {
            if (_repository == null)
                return null;
            
            var results = new List<Post>();
            string[] words;
            switch (ricercaEsatta)
            {
                case true:
                    words = text.Split(' ', '\t', '\r', '\n');
                    foreach (var post in _repository.Values)
                    {
                        foreach (var word in words)
                        {
                            if (post.SearchTrie.HasWord(word))
                            {
                                results.Add(post);
                                break;
                            }
                        }
                    }

                    break;
                case false:
                    words = Utilities.PreprocessInputText(text);
                    foreach (var post in _repository.Values)
                    {
                        foreach (var word in words)
                        {
                            if (post.SearchTrie.HasPrefix(word))
                            {
                                results.Add(post);
                                break;
                            }
                        }
                    }

                    break;
            }         

            return results;
        }

        public void InitializeRepository(IEnumerable<Post> rawPostList)
        {
            //TODO: check stopWatch for initialization performance
            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (var post in rawPostList)
            {
                Utilities.GenerateTrie(post);
                _repository.Add(post.Id, post);
            }
            watch.Stop();
            var time = watch.Elapsed;   
            //10 secondi di inizializzazione per 30k records
            //8 secondi per 20k records
        }

        public IEnumerable<Post> GetRepository()
        {
            return _repository.Values;
        }
    }
}
