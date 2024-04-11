using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace bussiness_social_media.MVVM.Model.Repository
{
    public interface ICommentRepository
    {
        List<Comment> GetAllComments();
        Comment GetCommentById(int id);
        int AddComment(string username, string content, DateTime dateOfCreation, DateTime dateOfUpdate);
        void UpdateComment(int id, string username, string content, DateTime dateOfCreation, DateTime dateOfUpdate);
        void DeleteComment(int id);

    }
    internal class CommentRepository : ICommentRepository
    {
        private List<Comment> _comments;
        private string _xmlFilePath;

        public CommentRepository(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
            _comments = new List<Comment>();
            LoadCommentsFromXml();
            SaveCommentsToXml();
        }

        ~CommentRepository()
        {
            SaveCommentsToXml();
        }


        private void LoadCommentsFromXml()
        {
            try
            {
                _comments = new List<Comment>();
                if (File.Exists(_xmlFilePath))
                {
                    // As explained in FAQ Repository
                    // This should look for the root element of ArrayOfComments
                    // But works only for root element of Comment
                    // Maybe it is a personal skill issue and this line is actually correct
                    // If shit goes south, look into this :* xoxo gossip girl
                    XmlSerializer serializer = new XmlSerializer(typeof(Comment), new XmlRootAttribute("Comment"));

                    using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Open))
                    {
                        using (XmlReader reader = XmlReader.Create(fileStream) )
                        {
                            while (reader.ReadToFollowing("Comment"))
                            {
                                Comment comment = (Comment)serializer.Deserialize(reader);
                                _comments.Add(comment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something terrible, terrible has happened during the execution of the program. Show this to your local IT guy: " + ex.Message);
            }
        }

        private void SaveCommentsToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Comment>), new XmlRootAttribute("ArrayOfComments"));

            using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, _comments);
            }

        }
        private int _getNextId()
        {
            return _comments.Count > 0 ? _comments.Max(comment => comment.Id) + 1 : 1;
        }

        public int AddComment(string username, string content, DateTime dateOfCreation, DateTime dateOfUpdate)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment(int id, string username, string content, DateTime dateOfCreation, DateTime dateOfUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
