
using bussiness_social_media.MVVM.Model.Repository;

namespace business_social_media.Services
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        void AddPost(DateTime creationDate, string imagePath, string caption);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
    public class PostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        public void AddPost(DateTime creationDate, string imagePath, string caption)

        {
            _postRepository.AddPost(creationDate, imagePath, caption);
        }

        public void UpdatePost(Post post)
        {
            _postRepository.UpdatePost(post);
        }

        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }
    }
}
