using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public class SqlConnector : IDataConnection
    {
        /// <summary>
        /// Saves a Post to the database
        /// </summary>
        /// <param name="submittedPost"></param>
        /// <returns></returns>
        public Post CreatePost(Post submittedPost)
        {
            //I could put any IDbConnection into connection - here I put a SqlConnection
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("knowledgeDb")))
            {
                var p = new DynamicParameters();
                p.Add("@Author", submittedPost.Author);
                p.Add("@Title", submittedPost.Title);
                p.Add("@Description", submittedPost.Description);
                p.Add("@SubmitDate", submittedPost.SubmitDate);
                p.Add("@LastModified", submittedPost.LastModified);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);    //both enums - if it's output variable in SQL, I can use it as both input and output

                connection.Execute("dbo.spPost_Insert", p, commandType: CommandType.StoredProcedure);

                submittedPost.Id = p.Get<int>("@Id");

                return submittedPost;
            }
        }
    }
}
