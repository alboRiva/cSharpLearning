using knowledgeBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

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
        public void AddPost(Post submittedPost)
        {
            // verifiche e azioni da eseguire
            //  lock in scrittura (il file può essere condiviso da più client e l'applicazione non è client server)
            //  se il lock non funziona attendere un tempo ragionevole trascorso il quale dare errore
            //  se il lock ha esito positivo verificare che il lastModifiedTime della riga di cui stai facendo il post sul file
            //      (se la riga esiste già e quindi si tratta di modifica) non sia superiore al valore presente nell'oggetto che si sta passando
            //      questa verifica deve essere fatta matchando l'id della riga di cui si sta facendo il post con l'id della riga sul file
            //      se l'id della riga corrente è pari a Guid.Empty significa che si tratta di un post nuovo e dovrebbe avere lastrModifiedTimer pari
            //      a DateTime.MinValue

            //Loads repository of posts in memory
            //TODO: gestione di accesso concorrente - gestione di IOException
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
                    _repository.Add(new Post(Guid.NewGuid(), submittedPost.Author, submittedPost.Title, submittedPost.Description, DateTime.UtcNow));
                }
                else
                {
                    //Check if submittedPost is effectively the last modified - if so, add it to the db 
                    if(DateTime.Compare(GetPostFromRepo(submittedPost.Id).LastModifiedTime,submittedPost.LastModifiedTime) < 0)
                    //Removes the old copy of the post based on guid comparison
                        _repository.Remove(submittedPost);
                    //Adds the new submitted post with the same Guid
                    _repository.Add(submittedPost);
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
                    writer.WriteStartElement("tags");
                        foreach (var tag in post.Tags)
                        {
                            writer.WriteElementString("tag", tag);
                        }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndDocument();
                return doc;
            }
        }

        public IEnumerable<Post> GetPostList(IEnumerable<string> tags)
        {
            //Loads Posts in memory 
            LoadRepository();

            if (tags == null || !tags.Any())
                return _repository;
            //Return all the posts which contain at least 
            return _repository.Where(post => {
                return post.Tags.Any(t => tags.Any(tt => String.Compare(t, tt, StringComparison.OrdinalIgnoreCase) == 0));
                });
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
            System.Diagnostics.Debug.WriteLine("Repo Loaded  ----");
        }

        private Post DecodePostFromXmlElement(XElement item)
        {
            Guid id = new Guid(item.Attribute("id").Value);
            string dateTime = item.Attribute("lastModificationTime").Value;
            // lastModificationTime="2018-10-06T20:08:54.4375781Z"
            //DateTime lastModificationDate = DateTime.ParseExact(dateTime, "yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK", CultureInfo.InvariantCulture);
            DateTime lastModificationDate = DateTime.Parse(dateTime,CultureInfo.InvariantCulture,DateTimeStyles.AdjustToUniversal);

            return new Post(id
                    , item.Attribute("author").Value
                    , item.Element("title").Value
                    , item.Element("description").Value
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

        //Gets a post without calling LoadRepository() - which would cause IOException
        public Post GetPostFromRepo(Guid Id)
        {
            foreach(var post in _repository)
            {
                if (post.Id.Equals(Id))
                    return post;
            }

            return null;
        }

        public void DeletePost(Post post)
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
}
