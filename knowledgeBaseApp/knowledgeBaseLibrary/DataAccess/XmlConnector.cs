﻿using knowledgeBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using knowledgeBaseLibrary.Exceptions;

namespace knowledgeBaseLibrary.DataAccess
{
    public class XmlConnector : IDataConnection
    {
        private List<Post> _repository;
        public string FileName { private set; get; }
        
        public XmlConnector(string fileName)
        {
            FileName = fileName;
            LoadRepository();
        }
        public void AddOrUpdatePost(Post submittedPost, bool forceSaveIfInConflict = false)
        {
            //Loads repository of posts in memory
            using (FileStream file = new FileStream(FileName,FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                LoadRepository(file);
                //Riposiziona il file all'inizio
                file.Seek(0, SeekOrigin.Begin);
                

                //checks if the submitted post is new or the user wants to edit an existing one
                bool newPost = submittedPost.Id.Equals(Guid.Empty) &&
                               submittedPost.LastModifiedTime.Equals(DateTime.MinValue);

                if (newPost)
                {
                    if (_repository.Select(t => t.Title).Contains(submittedPost.Title))
                    {
                        throw new Exceptions.TitleAlreadyPresentInDBException("The title is already present in the database");
                    }
                    _repository.Add(new Post(Guid.NewGuid(), submittedPost.Author, submittedPost.Title, submittedPost.Description, DateTime.UtcNow));
                }
                else
                {                  
                    //Check if submittedPost is effectively the last modified - if so, add it to the db 
                    if (!forceSaveIfInConflict &&
                        DateTime.Compare(GetPostFromRepo(submittedPost.Id).LastModifiedTime,
                            submittedPost.LastModifiedTime) > 0)
                        throw new Exceptions.ModifiedByOtherUserException($"The status of the element was changed by some other user after the read");
                    
                    //update lastmodified
                    submittedPost.LastModifiedTime = DateTime.UtcNow;
                    _repository[_repository.IndexOf(submittedPost)].CopyData(submittedPost);

                }
                XDocument docx = DecodeXDocFromPosts(_repository);
                docx.Save(file);
                //tronca il resto del file
                var length = file.Position;
                file.SetLength(length);
            }
        }

        /// <summary>
        /// Decodes all the posts in a list to Xml format, saving it
        /// </summary>
        /// <param name="postList"></param>
        /// <returns></returns>
        private XDocument DecodeXDocFromPosts(IEnumerable<Post> postList)
        {
            XDocument doc = new XDocument();
            using (XmlWriter writer = doc.CreateWriter())
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("posts");
                foreach (var post in postList)
                {
                    writer.WriteStartElement("post");
                    writer.WriteAttributeString("id", post.Id.ToString());
                    writer.WriteAttributeString("author", post.Author);
                    //<![CDATA[title test]]>
                    writer.WriteAttributeString("lastModificationTime", post.LastModifiedTime.ToString("o"));
                    writer.WriteStartElement("title");
                    writer.WriteCData(post.Title);
                    writer.WriteEndElement();
                    writer.WriteStartElement("description");
                    writer.WriteCData(post.Description);
                    writer.WriteEndElement();
                    //Don't need tags like this anymore
                    //writer.WriteStartElement("tags");
                    //    foreach (var tag in post.SearchTrie)
                    //    {
                    //        writer.WriteElementString("tag", tag);
                    //    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndDocument();
                return doc;
            }
        }
        /// <summary>
        /// Returns first 100 entries of repository if tags == null, returns matching tags if tags != null
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public IEnumerable<Post> GetPostList(IEnumerable<string> tags,int pageNumber = 0, int itemsPerPage = Int32.MaxValue)
        {
            //Loads Posts in memory 

            //if (tags == null || !tags.Any())
            //    return _repository.Skip(pageNumber*itemsPerPage).Take(itemsPerPage);
            ////Return all the posts which contain at least one tag
            //return _repository.Where(post => {
            //    return post.SearchTrie.Any(t => tags.All(tt => String.Compare(t, tt, StringComparison.OrdinalIgnoreCase) == 0));
            //    }).Skip(pageNumber*itemsPerPage).Take(itemsPerPage);
            return null;
        }

        private void LoadRepository()
        {
            using (FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                LoadRepository(file);
            }
        }

        private void LoadRepository(FileStream stream)
        {
            _repository = new List<Post>();
            XElement xele = XElement.Load(stream);
            foreach (XElement item in (xele.Elements("post")))
            {
                _repository.Add(DecodePostFromXmlElement(item));
            }
        }

        private Post DecodePostFromXmlElement(XElement item)
        {
            Guid id = new Guid(item.Attribute("id")?.Value);
            string dateTime = item.Attribute("lastModificationTime")?.Value;
            DateTime lastModificationDate = DateTime.Parse(dateTime,CultureInfo.InvariantCulture,DateTimeStyles.AdjustToUniversal);

            return new Post(id
                    , item.Attribute("author")?.Value
                    , item.Element("title")?.Value
                    , item.Element("description")?.Value
                    , lastModificationDate);
        }

        public Post GetPost(Guid id)
        {
            LoadRepository();
            foreach (var post in _repository)
            {
                if (post.Id.Equals(id))
                    return post;
            }

            return null;
        }

        //Gets a post without calling LoadRepository() 
        public Post GetPostFromRepo(Guid id)
        {
            foreach(var post in _repository)
            {
                if (post.Id.Equals(id))
                    return post;
            }

            return null;
        }

        public void DeletePost(Post post)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this post?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                LoadRepository();
                _repository.Remove(post);
                using (FileStream file = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    XDocument docx = DecodeXDocFromPosts(_repository);
                    docx.Save(file);
                }
            }
        }

        public IEnumerable<Post> SearchPost(string text)
        {
            throw new NotImplementedException();
        }

        public void UpdateRepository(IEnumerable<Post> rawPostList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetRepository()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> SearchPost(string text, bool ricercaEsatta)
        {
            throw new NotImplementedException();
        }

        public void InitializeRepository(IEnumerable<Post> rawPostList)
        {
            throw new NotImplementedException();
        }
    }
}
