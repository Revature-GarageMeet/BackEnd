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

    [HttpGet("GetPostByPostID/{postID}")]
    public async Task<Post> getPostByPostUserID(int postID)
    {
        Post post = new Post();
        return await _db.GetPostByPostID(postID);
    }

    [HttpGet("GetPostByBandID/{bandId}")]
    public async Task<List<Post>> getPostbyBandID(int bandId)
    {
        return await _db.getPostbyBandIdAsync(bandId);
    }

    [HttpPost("PostForBandMembers/{bandId}/{textEntry}/{userID}/{postType}")]
    public async Task postForBand(int bandId, string textEntry, int userID, string postType)
    {
        // We could specify the user later
        await _db.postForBandMemsAsync(bandId, textEntry, userID, postType);
    }

    [HttpPost("PostForBand/{bandId}/{textEntry}/{postType}")]
    public async Task postForBand(int bandId, string textEntry, string postType)
    {
        // We could specify the user later
        await _db.postForBandAsync(bandId, textEntry, postType);
    }

    //NOT NEEDED SINCE PostForUserID already gets user --Tucker
    // [HttpPost("PostForUser/{user}/{textEntry}/{postType}")]
    // public async Task postForUser(User user, string textEntry, string postType)
    // {
    //     await _db.postForUserAsync(user, textEntry, postType);
    // }

    [HttpPost("PostForUserId/{userId}/{textEntry}/{postType}")]
    public async Task postForUserId(int userId, string textEntry, string postType)
    {
        await _db.postForUserIdAsync(userId, textEntry, postType);
    }

    [HttpGet("GetLikes/{userId}")]
    public async Task<List<LikedPosts>>GetUserLikesAsync(int userId)
    {
        return await _db.GetUserLikesAsync(userId);
    }

    [HttpPut("LikePost/{postId}/{userId}")]
    public async Task likePostAsync(int postId, int userId)
    {
        await _db.LikePostAsync(postId, userId);
    }
    

    [HttpGet("GetPostLikes/{postId}")]
    public async Task<int> GetPostLikesAsync(int postId)
    {
        return await _db.GetPostLikesAsync(postId);
    }

    [HttpGet("GetAllPosts")]
    public async Task<List<Post>> GetAllPosts()
    {
        return await _db.getAllPosts();
    }
    
    [HttpDelete("UnlikePost/{postId}/{userId}")]
    public async Task UnlikePostAsyinc(int postId, int userId)
    {
        await _db.UnlikePostAsync(postId, userId);
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