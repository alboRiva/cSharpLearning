using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rm.Trie;
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
        public DateTime LastModifiedTime { get;  set; }
        /// <summary>
        /// Suffix trie associated to the post
        /// </summary>
        public Trie SearchTrie;   

        /// <summary>
        /// Constructor for a Post - Author SubmitDate and LastModified taken care by constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public Post(Guid id, string author, string title, string description, DateTime lastModifiedTime) : this(author,title,description)
        {
            Id = id;
            LastModifiedTime = lastModifiedTime;
            //TODO: need to generate trie in constructor?
            //SearchTrie = GenerateTrie(title, description);
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
            //Generate trie from title and description
            //TODO: search on description -> problem: HTML formatted text
            //TODO: need for generateTrie in constructor?
            //SearchTrie = GenerateTrie(this);
        }

        /// <summary>
        /// default ctor
        /// </summary>
        public Post() 
        {
            Id = Guid.NewGuid();
        }

        public void CopyData(Post post)
        {
            Author = post.Author;
            Title = post.Title;
            Description = post.Description;
            LastModifiedTime = DateTime.UtcNow;
            //SearchTrie = Utilities.GetTagsListFromString(Title, true);
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

