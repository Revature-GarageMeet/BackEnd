using Xunit;
using Moq;
using Models;
using Datalayer;
using WebAPI.Controllers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Tests;

/// <summary>
///     Author: Jose
///     Context: Created test for Comment controller, Comment Model
/// </summary>
public class CommentTests
{
    public Mock<DBInterface> mock = new Mock<DBInterface>();

    // Test model
    [Fact]
    public void GetSetCommentID()
    {
        Comment comment = new Comment();

        comment.id = 3;

        Assert.Equal(3, comment.id);
    }

    [Fact]
    public void GetSetUserID()
    {
        Comment comment = new Comment();

        comment.userId = 6;

        Assert.Equal(6, comment.userId);
    }

    [Fact]
    public void GetSetPostID()
    {
        Comment comment = new Comment();

        comment.postId = 2;

        Assert.Equal(2, comment.postId);
    }

    [Fact]
    public void GetSetEntry()
    {
        Comment comment = new Comment();

        comment.entry = "Test comment entry";

        Assert.Equal("Test comment entry", comment.entry);
    }

    [Fact]
    public void GetSetLikes()
    {
        Comment comment = new Comment();

        comment.likes = 7;

        Assert.Equal(7, comment.likes);
    }

    [Fact]
    public void GetSetDate()
    {
        Comment comment = new Comment();

        DateTime currDate = DateTime.UtcNow;

        comment.dateCreated = currDate;

        Assert.Equal(currDate, comment.dateCreated);
    }
    // End of model tests

    // Test Controller
    [Fact]
    public async Task CreateComment()
    {
        DateTime currDate = DateTime.UtcNow;

        Comment testComment = new Comment
        {
            userId = 4,
            postId = 6,
            entry = "test entry",
            likes = 2,
            dateCreated = currDate
        };

        Comment expectedComment = new Comment
        {
            userId = 4,
            postId = 6,
            entry = "test entry",
            likes = 2,
            dateCreated = currDate
        };

        mock.Setup(db => db.AddCommentAsync(testComment));

        CommentController com = new CommentController(mock.Object);

        await com.Post(testComment);

        Assert.Equal(expectedComment.userId, testComment.userId);
        Assert.Equal(expectedComment.postId, testComment.postId);
        Assert.Equal(expectedComment.entry, testComment.entry);
        Assert.Equal(expectedComment.likes, testComment.likes);
        Assert.Equal(expectedComment.dateCreated, testComment.dateCreated);

        mock.Verify(dl => dl.AddCommentAsync(testComment), Times.Once());
    }

    [Fact]
    public async Task GetComment()
    {
        int testCommentId = 1;

        DateTime currDate = DateTime.UtcNow;

        Comment fakeComment = new Comment
        {
            id = 1,
            userId = 2,
            postId = 3,
            entry = "",
            likes = 4,
            dateCreated = currDate
        };

        mock.Setup(dl => dl.GetCommentAsync(testCommentId)).ReturnsAsync(fakeComment);

        CommentController com = new CommentController(mock.Object);

        Comment comment = await com.Get(testCommentId);

        Assert.Equal(fakeComment, comment);

        mock.Verify(dl => dl.GetCommentAsync(testCommentId), Times.Once());
    }

    [Fact]
    public async Task GetAllComments()
    {
        int testPostId = 1;

        DateTime currDate = DateTime.UtcNow;

        List<Comment> fakeComments = new List<Comment>
        {
            new Comment
            {
                id = 1,
                userId = 2,
                postId = 3,
                entry = "",
                likes = 4,
                dateCreated = currDate
            },
            new Comment
            {
                id = 2,
                userId = 2,
                postId = 3,
                entry = "",
                likes = 4,
                dateCreated = currDate
            },
            new Comment
            {
                id = 3,
                userId = 2,
                postId = 3,
                entry = "",
                likes = 4,
                dateCreated = currDate
            }
        };

        mock.Setup(dl => dl.GetAllCommentsAsync(testPostId)).ReturnsAsync(fakeComments);

        CommentController com = new CommentController(mock.Object);

        List<Comment> comments = await com.GetAll(testPostId);

        Assert.Equal(fakeComments, comments);

        mock.Verify(dl => dl.GetAllCommentsAsync(testPostId), Times.Once());
    }

    [Fact]
    public async Task UpdateComment()
    {
        DateTime currDate = DateTime.UtcNow;

        Comment updatedFakeComment = new Comment
        {
            id = 1,
            userId = 2,
            postId = 3,
            entry = "",
            likes = 4,
            dateCreated = currDate
        };

        mock.Setup(dl => dl.UpdateCommentAsync(updatedFakeComment)).ReturnsAsync(updatedFakeComment);

        CommentController com = new CommentController(mock.Object);

        Comment comment = await com.Put(updatedFakeComment);

        Assert.Equal(updatedFakeComment, comment);

        mock.Verify(dl => dl.UpdateCommentAsync(updatedFakeComment), Times.Once());
    }
    // End of controller tests
}