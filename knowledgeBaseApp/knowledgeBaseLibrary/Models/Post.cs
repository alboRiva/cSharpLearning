using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary.Models
{
    public class Post
    {
        public Guid Id { get; private set; }
        /// <summary>
        /// Represents the LAST author who modified the post
        /// </summary>
        public String Author { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime LastModifiedTime { get; private set; }
        /// <summary>
        /// List of tags associated to the post
        /// </summary>
        public IEnumerable<string> Tags { get; set; } = new List<string>();      //new in C# 6

        /// <summary>
        /// Constructor for a Post - Author SubmitDate and LastModified taken care by constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public Post(Guid id, string author, string title, string description, DateTime lastModifiedTime)
        {
            Id = id;

            Author = author;

            //Author = Environment.UserName;
            //Author = System.Security.Principal.WindowsIdentity.GetCurrent().Name; -> returns DomainName\UserName

            Title = title;
            Description = description;
            LastModifiedTime = lastModifiedTime;

            Tags = GetTagsFromTitle();
        }

        /// <summary>
        /// Creates a new post ready for submission: Guid = Guid.Empty and LastModifiedTime = DateTime.MinValue;
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public Post(string author, string title, string description)
        {
            Id = Guid.Empty;
            Author = author;
            Title = title;
            Description = description;
            //LastModifiedTime = DateTime.UtcNow;
            LastModifiedTime = DateTime.MinValue;
            Tags = GetTagsFromTitle();
        }

        private IEnumerable<string> GetTagsFromTitle()
        {
            // make it more complex
            return Title.Split(' ', '\t', '\r', '\n' /*, ...*/);
        }

        public void printPost()
        {
            System.Diagnostics.Debug.WriteLine("titolo - {0} - descrizione: {1} tag: {2} ", Title, Description, Tags.First());
        }

        public override bool Equals(object obj)
        {
            return this.Equals((Post)obj);
        }

        public bool Equals(Post post)
        {
            if (post == null)
                return false;

            if (Id.Equals(post.Id))
                return true;

            return false;
        }
    }
}

