using BulletinBoard_Api.Data;
using BulletinBoard_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard_Api.Services;

public class PostService : IPostService
{
    private readonly BulletinBoardContext _ctx;

    public PostService(BulletinBoardContext ctx) { _ctx = ctx; }
    public async Task<bool> AddPost(string title, string? body, Guid authorId) {
        Account? acc = await _ctx.Account.FindAsync(authorId);
        if (acc is null || !acc.IsOnline)
            return false;
        
        Post p = new()
        {
            Title = title,
            Body = body,
            Author = authorId,
            Date = DateTime.Now,
        };
        await _ctx.Post.AddAsync(p);

        await _ctx.SaveChangesAsync();
        return true;

    }
    

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        return await _ctx.Post.ToListAsync();
    }

    public async Task<Post?> GetPostById(Guid id)
    {
        return await _ctx.Post.FindAsync(id);
        
    }

    public async Task<IEnumerable<Post>?> GetPostsByAuthor(Guid authorId)
    {
        IQueryable<Post> posts = 
            _ctx.Post.Where(post => post.Author == authorId)
                     .Select(post=>post);
        return await posts.AnyAsync() ? posts : null;
    }
}