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
        post.type = true;

        Assert.True(post.type);
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
                type = true
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
                type = true
            }
        };

        mock.Setup(dl => dl.getPostbyUserIdAsync(testUserId)).ReturnsAsync(testPost);

        PostController mockPost = new PostController(mock.Object);

        List<Post> post = await mockPost.getPostbyUserID(testUserId);

        Assert.Equal(testPost, post);

        mock.Verify(dl => dl.getPostbyUserIdAsync(testUserId));
    }
}