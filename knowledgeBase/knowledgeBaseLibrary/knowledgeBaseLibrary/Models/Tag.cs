using System;
using System.Collections.Generic;

namespace knowledgeBaseLibrary.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public String Name { get; set; }
        /// <summary>
        /// Number of posts the tag is referred by
        /// </summary>
        public int ReferenceCount { get; set; }              //keeping track of count in order to sort
        /// <summary>
        /// Keeps track of the number of upvotes
        /// </summary>
        public int UpvotesCount { get; set; }
        /// <summary>
        /// List of posts the tags refers to
        /// TODO: system for adding tags on submit
        /// </summary>
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
