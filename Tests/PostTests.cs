using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Datalayer;
using WebAPI.Controllers;

namespace Tests;

public class PostsTests
{
    public Mock<DBInterface> mock = new Mock<DBInterface>();

    [Fact]
    public void GetSetPostID()
    {
        Post post = new Post();
        post.id = 1;

        Assert.Equal(1, post.id);
    }

    [Fact]
    public void GetSetUserID()
    {
        Post post = new Post();
        post.userId = 1;

        Assert.Equal(1, post.userId);
    }

    [Fact]
    public void GetSetEntry()
    {
        Post post = new Post();
        post.entry = "test";

        Assert.Equal("test", post.entry);
    }

    [Fact]
    public void GetSetLikes()
    {
        Post post = new Post();
        post.likes = 1;

        Assert.Equal(1, post.likes);
    }

    [Fact]
    public void GetSetDate()
    {
        Post post = new Post();
        DateTime date = DateTime.UtcNow;
        post.dateCreated = date;

        Assert.Equal(date, post.dateCreated);
    }

    [Fact]
    public void GetSetBandId()
    {
        Post post = new Post();
        post.bandId = 1;

        Assert.Equal(1, post.bandId);
    }

    [Fact]
    public void GetSetType()
    {
        Post post = new Post();

        Assert.Equal("",post.type);
    }

    [Fact]
    public void GetSetPostComments()
    {
        Comment comment = new Comment();
        List<Comment> postComments = new List<Comment>();
        postComments.Add(comment);

        Assert.Equal(comment, postComments[0]);
    }

    // Test Controller
    [Fact]
    public async Task GetPostsByBandID()
    {
        int testBandId = 4;
        DateTime date = DateTime.UtcNow;
        List<Post> testPost = new List<Post>
        {
            new Post
            {
                id = 1,
                entry = "",
                userId = 2,
                likes = 3,
                dateCreated = date,
                bandId = 4,
                type = ""
            }
        };

        mock.Setup(dl => dl.getPostbyBandIdAsync(testBandId)).ReturnsAsync(testPost);

        PostController mockPost = new PostController(mock.Object);

        List<Post> post = await mockPost.getPostbyBandID(testBandId);

        Assert.Equal(testPost, post);

        mock.Verify(dl => dl.getPostbyBandIdAsync(testBandId));
    }

    [Fact]
    public async Task GetPostsByUserID()
    {
        int testUserId = 4;
        DateTime date = DateTime.UtcNow;
        List<Post> testPost = new List<Post>
        {
            new Post
            {
                id = 1,
                entry = "",
                userId = 4,
                likes = 2,
                dateCreated = date,
                bandId = 3,
                type = ""
            }
        };

        mock.Setup(dl => dl.getPostbyUserIdAsync(testUserId)).ReturnsAsync(testPost);

        PostController mockPost = new PostController(mock.Object);

        List<Post> post = await mockPost.getPostbyUserID(testUserId);

        Assert.Equal(testPost, post);

        mock.Verify(dl => dl.getPostbyUserIdAsync(testUserId));
    }

    [Fact]
    public async Task GetPostByUser()
    {
        User testUser = new User() {id = 1};
        DateTime date = DateTime.UtcNow;
        List<Post> testPost = new List<Post>
        {
            new Post
            {
                id = 2,
                entry = "",
                userId = 1,
                likes = 3,
                dateCreated = date,
                bandId = 4,
                type = ""
            }
        };

        mock.Setup(dl => dl.GetPostsByUserAsync(testUser)).ReturnsAsync(testPost);
        PostController mockPost = new PostController(mock.Object);
        List<Post> post = await mockPost.GetPostsByUser(testUser);
        Assert.Equal(testPost, post);
        mock.Verify(dl => dl.GetPostsByUserAsync(testUser));
    }

    [Fact]
    public async Task PostForBand()
    {
        Post newPost = new Post()
        {
            bandId = 1,
            entry = "test"
        };

        mock.Setup(db => db.postForBandAsync(newPost.bandId, newPost.entry, newPost.type));
        PostController mockPost = new PostController(mock.Object);
        await mockPost.postForBand(newPost.bandId, newPost.entry, newPost.type);
        mock.Verify(dl => dl.postForBandAsync(newPost.bandId, newPost.entry, newPost.type));
    }

    // [Fact]
    // public async Task postForUser()
    // {
    //     User testUser = new User() {id = 1};
    //     string textEntry = "test";
    //     string postType = "";

    //     mock.Setup(db => db.postForUserAsync(testUser, textEntry, postType));
    //     PostController mockPost = new PostController(mock.Object);
    //     await mockPost.postForUser(testUser, textEntry, postType);
    //     mock.Verify(dl => dl.postForUserAsync(testUser, textEntry, postType));
    // }

    [Fact]
    public async Task postForUserId()
    {
        int testUserId = 1;
        string testTextEntry = "";
        string testPostType = "";

        mock.Setup(db => db.postForUserIdAsync(testUserId, testTextEntry, testPostType));
        PostController mockPost = new PostController(mock.Object);
        await mockPost.postForUserId(testUserId, testTextEntry, testPostType);
        mock.Verify(dl => dl.postForUserIdAsync(testUserId, testTextEntry, testPostType));
    }

    [Fact]
    public async Task likePost()
    {
        User testUser = new User();
        int testPostId = 1;

        mock.Setup(db => db.likePostAsync(testPostId, testUser.id));
        PostController mockPost = new PostController(mock.Object);
        await mockPost.likePost(testPostId, testUser.id);
        mock.Verify(dl => dl.likePostAsync(testPostId, testUser.id));
    }

    [Fact]
    public async Task Delete()
    {
        int testPostId = 1;

        mock.Setup(db => db.deletePostAsync(testPostId));
        PostController mockPost = new PostController(mock.Object);
        await mockPost.Delete(testPostId);
        mock.Verify(dl => dl.deletePostAsync(testPostId));
    }
}