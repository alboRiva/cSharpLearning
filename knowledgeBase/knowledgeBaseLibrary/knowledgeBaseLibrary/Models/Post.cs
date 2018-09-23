using System;
using System.Collections.Generic;

namespace knowledgeBaseLibrary.Models
{
    public class Post
    {

        public int Id { get; set; } 
        /// <summary>
        /// Represents the last author who modified the post
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
            Title = title;
            Description = description;
            SubmitDate = LastModified = DateTime.Today;
        }
    }
}
