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
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly repo _db;
    public PostController(repo db)
    {
        _db = db;
    }


    [HttpGet("GetPostbyUID/{userID}")]
    public async Task<List<Post>> getPost(int userId)
    {
        return await _db.GetPostByUserIDAsync(userId);
    }

    // Get Posts by user object ~ Matthew
    [HttpGet("GetPostsByUser")]
    /// <summary>
    /// Gets All the posts by a specific user by user object.
    /// </summary>
    /// /// <param name="user">User object to find posts for.</param>
    /// <returns>A List of Posts of all the posts by a specific user.</returns>
    public async Task<List<Post>> GetPostsByUser(User user)
    {
        return await _db.GetPostsByUserAsync(user);
    }
    
    [HttpGet("GetPostByBandID")]
    public async Task<List<Post>> getPostbyBandID(int bandId)
    {
        return await _db.GetPostByBandIDAsync(bandId);
    }

    [HttpPost("PostForBand")]
    public async Task postForBand(User user, int bandId, string textEntry)
    {
        // check if user is in the band or something
        await _db.postForBandAsync(bandId, textEntry);
    }

    [HttpPut("LikePost")]
    public async Task likePost(int postId, User user)
    {
        await _db.likePostAsync(postId, user);
    }
}
/*
    post create post
    get post
    get post=>like post?
*/