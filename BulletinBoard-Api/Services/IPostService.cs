using BulletinBoard_Api.Models;

namespace BulletinBoard_Api.Services;

public interface IPostService {
    public Task<IEnumerable<Post>> GetAllPosts();
    public Task<Post?> GetPostById(Guid id);
    public Task<IEnumerable<Post>?> GetPostsByAuthor(Guid authorId);

    

    public Task<bool> AddPost(string title, string? body, Guid authorId);


}