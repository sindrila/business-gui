using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bussiness_social_media.MVVM.Model.Repository
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        void AddPost(DateTime creationDate, string imagePath, string caption);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }

    public class PostRepository : IPostRepository
    {
        private List<Post> _posts;
        private string _xmlFilePath;

        private static Random _random = new Random();

        public PostRepository()
        {
            _posts = new List<Post>();
            generate10RandomPosts();
        }

        public PostRepository(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
            _posts = new List<Post>();
            generate10RandomPosts();
            SavePostsToXml();
            LoadPostsFromXml();
        }

        ~PostRepository()
        {
            SavePostsToXml();
        }

        private void generate10RandomPosts()
        {
            for (int i = 0; i < 10; i++)
            {
                DateTime creationDate = DateTime.Now.AddDays(-_random.Next(1, 30));
                string imagePath = $"Assets\\Images\\scat{i + 1}.jpg";
                string caption = $"This is post number {i + 1}";
                AddPost(creationDate, imagePath, caption);
            }
        }

        private void LoadPostsFromXml()
        {
            try
            {
                if (File.Exists(_xmlFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Post>), new XmlRootAttribute("ArrayOfPost"));

                    _posts = new List<Post>();

                    using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Open))
                    {
                        using (XmlReader reader = XmlReader.Create(fileStream))
                        {
                            // Move to the first Post element
                            while (reader.ReadToFollowing("Post"))
                            {
                                // Deserialize each Post element and add it to the list
                                Post post = (Post)serializer.Deserialize(reader);
                                _posts.Add(post);
                            }
                        }
                    }
                }
                else
                {
                    // Handle the case where the XML file doesn't exist
                    _posts = new List<Post>();
                }
            }
            catch { }
        }

        private void SavePostsToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Post>), new XmlRootAttribute("ArrayOfPost"));

            using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, _posts);
            }
        }

        public List<Post> GetAllPosts()
        {
            return _posts;
        }

        public Post GetPostById(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public void AddPost(DateTime creationDate, string imagePath, string caption)
        {
            int id = _getNextId();
            Post post = new Post(id, creationDate, imagePath, caption);
            _posts.Add(post);
            SavePostsToXml();
        }

        public void UpdatePost(Post post)
        {
            var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.SetNumberOfLikes(post.NumberOfLikes);
                existingPost.SetCreationDate(post.CreationDate);
                existingPost.SetImagePath(post.ImagePath);
                existingPost.SetCaption(post.Caption);
                existingPost.SetComments(post.CommentIds);
                SavePostsToXml();
            }
        }

        public void DeletePost(int id)
        {
            var postToRemove = _posts.FirstOrDefault(p => p.Id == id);
            if (postToRemove != null)
            {
                _posts.Remove(postToRemove);
                SavePostsToXml();
            }
        }

        private int _getNextId()
        {
            return _posts.Count > 0 ? _posts.Max(p => p.Id) + 1 : 1;
        }
    }
}