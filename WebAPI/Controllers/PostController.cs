using Microsoft.AspNetCore.Mvc;
using Datalayer;
using Models;

/* temporary comment - post model
    int id - unique post id
    string entry - text in post
    int userid - who is this from 
    int likes - num of likes
    date datecreated - when created
    int bandid - who does this belong to
    type type //post based on band/user posts (use bool for it or maybe int for id type) ~ leo
    ~~~~~~~~~~~~~
    We need getPost, createPost, likePost ~ rey
    getpostbyID? getPostbyBandID&userID, createPostforBand, createPostforSelf
*/


namespace WebAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly DBInterface _db;
    public PostController(DBInterface db)
    {
        _db = db;
    }


    [HttpGet("GetPostbyUID/{userId}")]
    public async Task<List<Post>> getPostbyUserID(int userId)
    {
        return await _db.getPostbyUserIdAsync(userId);
    }

    // Get Posts by user object ~ Matthew
    [HttpGet("GetPostsByUser/{user}")]
    /// <summary>
    /// Gets All the posts by a specific user by user object.
    /// </summary>
    /// <param name="user">User object to find posts for.</param>
    /// <returns>A List of Posts of all the posts by a specific user.</returns>
    public async Task<List<Post>> GetPostsByUser([FromQuery] User user)
    {
        return await _db.GetPostsByUserAsync(user);
    }

    [HttpGet("GetPostByBandID/{bandId}")]
    public async Task<List<Post>> getPostbyBandID(int bandId)
    {
        return await _db.getPostbyBandIdAsync(bandId);
    }

    [HttpPost("PostForBand/{bandId}/{textEntry}")]
    public async Task postForBand(int bandId, string textEntry)
    {
        // We could specify the user later
        await _db.postForBandAsync(bandId, textEntry);
    }

    [HttpPost("PostForUser/{user}/{textEntry}")]
    public async Task postForUser(User user, string textEntry)
    {
        await _db.postForUserAsync(user, textEntry);
    }

    [HttpPost("PostForUserId/{userId}/{textEntry}")]
    public async Task postForUserId(int userId, string textEntry)
    {
        await _db.postForUserIdAsync(userId, textEntry);
    }

    [HttpPut("LikePost/{postId}/{user}")]
    public async Task likePost(int postId, User user)
    {
        await _db.likePostAsync(postId, user);
    }

    [HttpDelete("DeletePost/{postId}")]
    public async Task Delete(int postId)
    {
        await _db.deletePostAsync(postId);
    }
}
/*
    post create post
    get post
    get post=>like post?
*/