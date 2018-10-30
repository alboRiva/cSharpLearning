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
        public Post(Guid id, string author, string title, string description, DateTime lastModifiedTime) : this(author,title,description)
        {
            Id = id;
            LastModifiedTime = lastModifiedTime;
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
            Tags = Utilities.GetTagsListFromString(title,true);
        }

        public void CopyData(Post post)
        {
            Author = post.Author;
            Title = post.Title;
            Description = post.Description;
            LastModifiedTime = DateTime.UtcNow;
            Tags = Utilities.GetTagsListFromString(Title, true);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
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

