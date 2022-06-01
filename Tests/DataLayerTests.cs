using Xunit;
using Moq;
using Models;
using Datalayer;
using WebAPI.Controllers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Tests;

public class DLTests
{
    public Mock<DBInterface> mock = new Mock<DBInterface>();
    private readonly DbContextOptions<GMDBContext> options;
    public DLTests()
    {
        options = new DbContextOptions<GMDBContext>().UseSqlite("Filename=test.db").Options;
        Seed();
    }


    private void Seed()
    {
        using(var context = new GMDBContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


        }
    }

    [Fact]
    public async Task DBGetAllPosts()
    {
        using (var context = new GMDBContext(options))
        {
            List<Post> testPosts = new List<Post>();
            testPosts = context.Posts.ToListAsync();

            Assert.NotNull(testPosts);
            
        }
    }


    [Fact]
    public async Task DBPostForBandMemsAsync()
    {
        using (var context = new GMDBContext(options))
        {
            Post post = new Post(){
                entry = "Test", 
                bandId = 1100, 
                type = "TestType", 
                dateCreated = DateTime(), 
                likes = 0, userId = 11};
            context.Posts.Add(post);

            Assert.NotNull(post);
            Assert.Equal("Test", post.entry);
            Assert.Equal(1100, post.bandId);
            Assert.Equal("TestType", post.type);
            Assert.Equal(11, post.userId);
            Assert.NotNull(post.dateCreated);
        
        }
    }
}