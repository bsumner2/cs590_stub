using System.ComponentModel.DataAnnotations;
using BulletinBoard_Api.Models;
using BulletinBoard_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase {

    private readonly IPostService _postService;

    public PostController(IPostService postService) {
        _postService = postService;
    }


    
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        return Ok(await _postService.GetAllPosts());
    }

    [HttpGet("ByAuthor")]
    public async Task<IActionResult> GetByAuthorId(Guid id) {
        IEnumerable<Post>? authoredPosts = await _postService.GetPostsByAuthor(id);
        return authoredPosts is null ? NotFound() : Ok(authoredPosts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(Guid id) {
        Post? post = await _postService.GetPostById(id);

        return post is null ? NotFound() : Ok(post);
    }

    [HttpPost("CreateNew")]
    public async Task<IActionResult> PutNewPost([Required] [FromBody] string[] titleAndBody, [Required] Guid authorId) {
        if (titleAndBody.Length!=2)
            return BadRequest("Malformed request body. Request body must have two-string array: {Title, Body}.");

        if (titleAndBody[0].Length == 0)
            return BadRequest("Post title must be a non-empty string.");
        
        if (titleAndBody[0].Length > 128)
            return BadRequest("Post title too long.");
        
        
        if (titleAndBody[1].Length > 256)
            return BadRequest("Post body too long.");

        if (!await _postService.AddPost(titleAndBody[0], titleAndBody[1].Length > 0 ? titleAndBody[1] : null, authorId))
            return NotFound("No online user found with given author ID. Cannot make post.");
        
        return Ok();
    }
}