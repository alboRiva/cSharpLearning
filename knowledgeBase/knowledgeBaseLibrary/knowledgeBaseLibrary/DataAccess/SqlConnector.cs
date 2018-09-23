using System.Data;
using Dapper;
using knowledgeBaseLibrary.Models;

namespace knowledgeBaseLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {

    
        //TODO: implement
        /// <summary>
        /// Saves a Post to the database
        /// </summary>
        /// <param name="submittedPost"></param>
        /// <returns></returns>
        public Post CreatePost(Post submittedPost)
        {

            //I could possibly put any type of connection. Anything that implements IDbConnection
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("knowledgeDB")))
            {
                var p = new DynamicParameters();
                p.Add("@Title", submittedPost.Title);
                p.Add("@Description", submittedPost.Description);
                p.Add("@Author", submittedPost.Author);
                p.Add("@Submit_Date", submittedPost.SubmitDate);
                p.Add("@Last_Modified", submittedPost.LastModified);
                p.Add("@Post_ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output /*Enum*/);

                connection.Execute("dbo.spPost_Insert", p, commandType: CommandType.StoredProcedure /*Enum*/);   //no information back with execute - opposite to query
                
                //capture ID 
                submittedPost.Id = p.Get<int>("@Post_ID");

                return submittedPost;
            }
        }
    }
}
