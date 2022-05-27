using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

/// <summary>
///     Author: Jose
///     Context: Comment controller
/// </summary>
[Route("[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly DBInterface _dl;

    public CommentController(DBInterface dl)
    {
        _dl = dl;
    }

    [HttpPost("AddComment/{postIdee}")] // to avoid name confusion, idee is for the passed in post id
    public async Task Post(Comment commentToAdd, int postIdee)
    {
        commentToAdd.postId = postIdee;
        await _dl.AddCommentAsync(commentToAdd);
    }

    [HttpGet("GetComment/{commentId}")]
    public async Task<Comment> Get(int commentId)
    {
        return await _dl.GetCommentAsync(commentId);
    }

    [HttpGet("GetAllComments/{postId}")]
    public async Task<List<Comment>> GetAll(int postId)
    {
        return await _dl.GetAllCommentsAsync(postId);
    }

    [HttpPut("UpdateComment")]
    public async Task<Comment> Put(Comment commentToUpdate)
    {
        return await _dl.UpdateCommentAsync(commentToUpdate);
    }
}