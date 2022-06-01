using System.Linq;
namespace Datalayer;
using System.Diagnostics.CodeAnalysis;



public class DatabaseCalls : DBInterface
{
    private readonly GMDBContext _context;
    public DatabaseCalls(GMDBContext context)
    {
        _context = context;
    }

    //please sort and comment based on the group's sections if we do ~leo
    //CODE ONLY, DOCUMENTATION (of what it does) GOES IN THE INTERFACE


    //User Login/Registration things
    public async Task<User> createUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> loginUser(string auth)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.username == auth);
    }
    public async Task<Boolean> checkExisting(string auth)
    {
        return await _context.Users.AnyAsync(user => user.username == auth);
    }
    // public async Task<Boolean> authenticateUser(string authUser, string authPass)
    // {
    //     return await _context.Users.AnyAsync(user => user.username == authUser && user.password == authPass);
    // }

    public async Task<User> otherProfileInfo(int userId)
    {
        User user = await _context.Users.FirstOrDefaultAsync(user => user.id == userId);
        user.password = "";
        user.email = "";
        return user;
    }

    public async Task<User> updateUser(User auth)
    {
        User temp = await _context.Users.FirstOrDefaultAsync(user => user.username == auth.username);
        temp.firstname = auth.firstname;
        temp.lastname = auth.lastname;
        temp.bio = auth.bio;
        await _context.SaveChangesAsync();
        return temp;
    }

    //************************************************ Post Related Things ************************************************

    public async Task<List<Post>> getAllPosts()
    {
        return await _context.Posts.ToListAsync();
    }


    // public async Task postForBandAsync(int bandId, string textEntry, string postType)
    // {
    //     Post post = new Post() { entry = textEntry, bandId = bandId, type = postType };
    //     _context.Posts.Add(post);
    //     await _context.SaveChangesAsync();
    // }

    public async Task postForBandMemsAsync(int bandId, string textEntry, int userID, string postType)
    {
        Post post = new Post() { entry = textEntry, bandId = bandId, userId = userID, type = postType };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task postForBandAsync(int bandId, string textEntry, string postType)
    {
        Post post = new Post() { entry = textEntry, bandId = bandId, type = postType };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task postForUserAsync(User user, string textEntry, string postType)
    {
        Post post = new Post() { entry = textEntry, userId = user.id, likes = 0, dateCreated = DateTime.Now, type = postType };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }
    public async Task postForUserIdAsync(int userId, string textEntry, string postType)
    {
        Post post = new Post() { entry = textEntry, userId = userId, likes = 0, dateCreated = DateTime.Now, type = postType };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task LikePostAsync(int postId, int userId)
    {

        // might not work, just put it here for now. Also allows for inifite likes

        LikedPosts testPost = await _context.LikedPosts.Where(t => t.postid == postId && t.userid == userId).SingleOrDefaultAsync();

        if (testPost == null)
        {
            testPost = new LikedPosts()
            {
                userid = userId,
                postid = postId
            };
            Console.WriteLine("Liking the Post");
            await _context.LikedPosts.AddAsync(testPost);
            await _context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine($"Un-Liking the Post");
            // _context.LikedPosts.Update(_context.LikedPosts.Remove(testPost));
            _context.LikedPosts.Remove(testPost);

            await _context.SaveChangesAsync();

            // try
            // {
            // _context.LikedPosts.Remove(testPost);

            // _context.SaveChanges();
            // }
            // catch(DbUpdateConcurrencyException ex)
            // {

            //     throw new Exception("Record does not exist in the database: " + ex.Message);
            // }
            // catch(Exception ex)
            // {
            //     throw;
            // }

        }


        // Post temp = await _context.Posts.FirstOrDefaultAsync(t => t.id == postId);
        // if (temp != null)
        // {
        //     temp.likes++;
        //     _context.Posts.Update(temp);
        // }
        // //_context.Posts.FromSqlRaw($"UPDATE Posts SET likes = likes + 1 WHERE id = {postId}");
        // await _context.SaveChangesAsync();
    }

    public async Task UnlikePostAsync(int postId, int userId)
    {
        //_context.Posts.FromSqlRaw($"DELETE from Posts WHERE id={postId}");
        LikedPosts temp = await _context.LikedPosts.FirstOrDefaultAsync(t => t.postid == postId && t.userid == userId);
        if (temp != null)
        {
            _context.LikedPosts.Remove(temp);
        }
        await _context.SaveChangesAsync();
    }


    public async Task<int> GetPostLikesAsync(int postId)
    {
        int postLikes = await _context.LikedPosts.CountAsync(t => t.postid == postId);
        return postLikes;
    }

    public async Task<List<LikedPosts>> GetUserLikesAsync(int userId)
    {
        return await _context.LikedPosts.AsNoTracking().Where(t => t.userid == userId).ToListAsync();
    }

    public async Task<bool> CheckIfLiked(int postId, int userId)
    {
        return await _context.LikedPosts.AnyAsync(liked => liked.postid == postId && liked.userid == userId);
    }





    

    /// <summary>
    ///     Author: Jose
    ///     Context: Creates comment in database
    /// </summary>
    /// <param name="commentToAdd"></param>
    /// <returns></returns>
    public async Task AddCommentAsync(Comment commentToAdd)
    {
        await _context.Comments.AddAsync(commentToAdd);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    ///     Author: Jose
    ///     Context: Gets comment by comment id from database
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns>Returns comment respective to the id</returns>
    public async Task<Comment> GetCommentAsync(int commentId)
    {
        return await _context.Comments.FirstOrDefaultAsync(comment => comment.id == commentId);
    }
    /// <summary>
    ///     Author: Jose
    ///     Context: Gets all comments from post id from database
    /// </summary>
    /// <param name="postId"></param>
    /// <returns>Returns list of comments respective to post id</returns>
    public async Task<List<Comment>> GetAllCommentsAsync(int postId)
    {
        return await _context.Comments.AsNoTracking().Where(comment => comment.postId == postId).ToListAsync();
    }
    /// <summary>
    ///     Author: Jose
    ///     Context: Updates the comment (likes, entry)
    /// </summary>
    /// <param name="commentToUpdate"></param>
    /// <returns>Returns the updated comment</returns>
    public async Task<Comment> UpdateCommentAsync(Comment commentToUpdate)
    {
        _context.Comments.Update(commentToUpdate);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return await _context.Comments.FirstOrDefaultAsync(comment => comment.id == commentToUpdate.id);
    }


    //Group/Team things

    //Band calls -Arrion
    public async Task<Band> CreateBand(Band newBand)
    {
        _context.Bands.Add(newBand);
        await _context.SaveChangesAsync();
        return newBand;
    }

    public async Task<Band> GetMemberLimit(int bandId)
    {
        return await _context.Bands.FirstOrDefaultAsync(band => band.id == bandId);
    }

    public async Task UpdateBand(Band changeBand)
    {
        _context.Bands.Update(changeBand);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
    }

    public async Task<List<Band>> GetBands(int bandId)
    {
        return await _context.Bands.FromSqlRaw($"Select * From Band Where Bands.bandId = {bandId}").ToListAsync();
    }

    public async Task<List<Band>> GetAllBands()
    {
        return await _context.Bands!.ToListAsync();
    }

    public async Task DeleteBand(int bandId)
    {
        Band tempBand = await _context.Bands.FirstOrDefaultAsync(band => band.id == bandId);
        _context.Bands.Remove(tempBand);
        await _context.SaveChangesAsync();
    }

    // Gets all members for a single Band ~Bailey
    public async Task<List<User>> GetAllBandMembers(int bandId)
    {
        List<User> bandMemUsers = new List<User>();
        List<BandMember> bandMem = new List<BandMember>();

        bandMem = await _context.BandMembers.FromSqlRaw($"Select * From BandMembers Where BandMembers.bandId = {bandId}").ToListAsync();
        foreach (BandMember mem in bandMem)
        {
            bandMemUsers.Add(await _context.Users.FirstOrDefaultAsync(user => user.id == mem.userId));
        }
        return bandMemUsers;
    }

    public async Task<BandMember> GetBandMember(int userId)
    {
        return await _context.BandMembers.FirstOrDefaultAsync(bandmem => bandmem.userId == userId);
    }

    //Note to me(Arrion) don't forget band limit

    // Adds new member to database ~Bailey
    public async Task<BandMember> CreateBandMember(BandMember newMember)
    {
        _context.BandMembers.Add(newMember);
        await _context.SaveChangesAsync();
        return newMember;
    }

    // Removes a member from the database ~Bailey
    public async Task RemoveBandMember(int bandMemId)
    {
        BandMember tempBandMem = await _context.BandMembers.FirstOrDefaultAsync(bandmem => bandmem.id == bandMemId);
        _context.BandMembers.Remove(tempBandMem);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsInABand(int userId)
    {
        return await _context.BandMembers.AnyAsync(bandmem => bandmem.userId == userId);
    }

    public async Task<bool> CheckIfBandExists(string bandTitle)
    {
        return await _context.Bands.AnyAsync(band => band.title == bandTitle);
    }

    public async Task<Band> GetBandDetails(string bandTitle)
    {
        return await _context.Bands.FirstOrDefaultAsync(band => band.title == bandTitle);
    }

    // not implemented
    public async Task<List<string>> GetAllBandNames(int bandId)
    {
        await _context.SaveChangesAsync();
        return new List<string>();
    }

    public Task<bool> authenticateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> checkExisting(User user)
    {
        throw new NotImplementedException();
    }

    #region Posts

    // public async Task LikePostAsync(int postId, int userId)
    // {
    
    //     // might not work, just put it here for now. Also allows for inifite likes
        
    //     LikedPosts testPost = await _context.LikedPosts.Where(t => t.postid == postId && t.userid == userId).SingleOrDefaultAsync();
        
    //     if(testPost == null) 
    //     {
    //         testPost = new LikedPosts()
    //         {
    //             userid = userId,
    //             postid = postId
    //         };
    //         Console.WriteLine("Liking the Post");
    //         await _context.LikedPosts.AddAsync(testPost);
    //         await _context.SaveChangesAsync();
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Un-Liking the Post");
    //         // _context.LikedPosts.Update(_context.LikedPosts.Remove(testPost));
    //         _context.LikedPosts.Remove(testPost);
            
    //         await _context.SaveChangesAsync();
            
    //         // try
    //         // {
    //         // _context.LikedPosts.Remove(testPost);

    //         // _context.SaveChanges();
    //         // }
    //         // catch(DbUpdateConcurrencyException ex)
    //         // {
                
    //         //     throw new Exception("Record does not exist in the database: " + ex.Message);
    //         // }
    //         // catch(Exception ex)
    //         // {
    //         //     throw;
    //         // }
            
    //     }
        
        
    //     // Post temp = await _context.Posts.FirstOrDefaultAsync(t => t.id == postId);
    //     // if (temp != null)
    //     // {
    //     //     temp.likes++;
    //     //     _context.Posts.Update(temp);
    //     // }
    //     // //_context.Posts.FromSqlRaw($"UPDATE Posts SET likes = likes + 1 WHERE id = {postId}");
    //     // await _context.SaveChangesAsync();
    // }

   public async Task deletePostAsync(int postId)
    {
        //_context.Posts.FromSqlRaw($"DELETE from Posts WHERE id={postId}");
        Post temp = await _context.Posts.FirstOrDefaultAsync(t => t.id == postId);
        if (temp != null)
        {
            _context.Posts.Remove(temp);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<Post> GetPostByPostID(int postID)
    {
        Post tempPost = await _context.Posts.FirstOrDefaultAsync(_post => _post.id == postID);
        tempPost.likes = await GetPostLikesAsync(postID);
        return tempPost;
    }

    public async Task<List<Post>> GetPostsByUserAsync(User user)
    {
        List<Post> temp = await _context.Posts.FromSqlRaw($"SELECT * FROM Posts WHERE userId = {user.id}").ToListAsync();
        foreach (Post _post in temp)
        {
            _post.likes = await GetPostLikesAsync(_post.id);
        }

        return temp;
    }
    public async Task<List<Post>> getPostbyUserIdAsync(int userId)
    {
        List<Post> temp = await _context.Posts.FromSqlRaw($"SELECT * FROM Posts WHERE userId = {userId}").ToListAsync();
        foreach (Post _post in temp)
        {
            _post.likes = await GetPostLikesAsync(_post.id);
        }
        return temp;
    }

    public async Task<List<Post>> getPostbyBandIdAsync(int bandId)
    {
        List<Post> temp = await _context.Posts.AsNoTracking().Where(post => post.bandId == bandId).ToListAsync();
        foreach (Post _post in temp)
        {
            _post.likes = await GetPostLikesAsync(_post.id);
        }
        return temp;
    }


  

    

    #endregion

    public async Task<User> GetUserByIDAsync(int userId)
    {
        User test = await _context.Users.FirstOrDefaultAsync(t => t.id == userId);
        test.password = "";

        return test;
    }

    public async Task<List<Post>> GetHomepagePostsAsync(int userId)
    {
        List<Post> tempPosts = await _context.Posts.AsNoTracking().Where(t => t.userId != userId).ToListAsync();
        return tempPosts;
    }

}


/*
    here's all the db calls we need to make ~leo
    also most things here should be async probably ~leo
    
    for user stuff:
        createUser(user user)
            uses -> checkExisting(user user) before pushing to db
        loginUser (user user)
            uses -> authenticateUser(user user) -> returns either the user or something if it dont work idk w/e 
    figure out password hashing for create user ^^ ~leo also prob rename things that dont make it sound like they came out of my brain cause its fucked in there

*/