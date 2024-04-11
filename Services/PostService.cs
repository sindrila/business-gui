
public class PostService
{
    private List<Post> _posts;

    public PostService()
    {
        _posts = new List<Post>();
        // initialize
    }

    public List<Post> GetAllPosts()
    {
        return _posts;
    }

    public Post GetPostById(int id)
    {
        return _posts.FirstOrDefault(p => p.Id == id);
    }

    public void AddPost(int businessId, DateTime creationDate, string imagePath, string caption)
    //public void AddPost(int id, int businessId, DateTime creationDate, string imagePath, string caption, Product product)

    {
        Post post = new Post(_getNextId(), businessId, creationDate, imagePath, caption);
    //    Post post = new Post(_getNextId(), businessId, creationDate, imagePath, caption, product);
        _posts.Add(post);
    }

    public void UpdatePost(Post post)
    {
        var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
        if (existingPost != null)
        {
            //existingPost.SetBusinessId(post.BusinessId);
            existingPost.SetNumberOfLikes(post.NumberOfLikes);
            existingPost.SetCreationDate(post.CreationDate);
            existingPost.SetImagePath(post.ImagePath);
            existingPost.SetCaption(post.Caption);
            existingPost.SetComments(post.Comments);
//            existingPost.SetProduct(post.Product);

        }
    }

    public void DeletePost(int id)
    {
        var postToRemove = _posts.FirstOrDefault(p => p.Id == id);
        if (postToRemove != null)
        {
            _posts.Remove(postToRemove);
        }
    }

    private int _getNextId()
    {
        return _posts.Count > 0 ? _posts.Max(p => p.Id) + 1 : 1;
    }

}
