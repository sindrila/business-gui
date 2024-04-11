
using bussiness_social_media.MVVM.Model.Repository;

namespace business_social_media.Services
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        int AddPost(DateTime creationDate, string imagePath, string caption);
        void UpdatePost(int id, DateTime newCreationDate, string newImagePath, string newCaption);
        void DeletePost(int id);
    }
    public class PostService : IPostService 
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

        public int AddPost(DateTime creationDate, string imagePath, string caption)

        {
            return _postRepository.AddPost(creationDate, imagePath, caption);
        }

        public void UpdatePost(int id, DateTime newCreationDate, string newImagePath, string newCaption)
        {
            Post postToUpdate = GetPostById(id);
            _postRepository.UpdatePost(postToUpdate);
        }

        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }

    }
}
