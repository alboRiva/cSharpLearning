using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public class Post
    {

        public int Id { get; set; } 
        /// <summary>
        /// Represents the LAST author who modified the post
        /// </summary>
        public String Author { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime LastModified { get; set; }
        /// <summary>
        /// List of tags associated to the post
        /// </summary>
        public List<Tag> Tags { get; set; } = new List<Tag>();      //new in C# 6

        /// <summary>
        /// Constructor for a Post - Author SubmitDate and LastModified taken care by constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public Post(string title, string description)
        {
            Id = Id++;
            Author = Environment.UserName;
            //Author = System.Security.Principal.WindowsIdentity.GetCurrent().Name; -> returns DomainName\UserName


            Title = title;
            Description = description;
            SubmitDate = LastModified = DateTime.Today;
        }
    }
}
