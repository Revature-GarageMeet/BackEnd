using System.Linq;
namespace Datalayer;


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
    public async Task<User> loginUser(User auth)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.username == auth.username && user.password == auth.password);
    }
    public async Task<Boolean> checkExisting(User auth)
    {
        return await _context.Users.AnyAsync(user => user.username == auth.username);
    }
    public async Task<Boolean> authenticateUser(User auth)
    {
        return await _context.Users.AnyAsync(user => user.username == auth.username && user.password == auth.password);
    }

    public async Task<User> updateUser(User auth)
    {
        User temp = await _context.Users.FirstOrDefaultAsync(user => user.username == auth.username);
        Console.WriteLine(temp.bio);
        temp.firstname = auth.firstname;
        temp.lastname = auth.lastname;
        temp.bio = auth.bio;
        await _context.SaveChangesAsync();

        Console.WriteLine(auth.bio);
        return temp;
    }

    //************************************************ Post Related Things ************************************************
    public async Task<List<Post>> GetPostsByUserAsync(User user)
    {
        // List<Post> temp = await _context.Posts.FromSqlRaw($"SELECT * FROM Posts WHERE userId = {user.id}").ToListAsync();
        // return temp;
        return await _context.Posts.FromSqlRaw($"SELECT * FROM Posts WHERE userId = {user.id}").ToListAsync();
    }
    public async Task<List<Post>> getPostbyUserIdAsync(int userId)
    {
        return await _context.Posts.FromSqlRaw($"SELECT * FROM Posts WHERE userId = {userId}").ToListAsync();
    }

    public async Task<List<Post>> getPostbyBandIdAsync(int bandId)
    {
        return await _context.Posts.AsNoTracking().Where(post => post.bandId == bandId).ToListAsync();
    }

    public async Task postForBandAsync(int bandId, string textEntry)
    {
        Post post = new Post() { entry = textEntry, bandId = bandId };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task postForUserAsync(User user, string textEntry)
    {
        Post post = new Post() { entry = textEntry, userId = user.id, likes = 0, dateCreated = DateTime.Now };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }
    public async Task postForUserIdAsync(int userId, string textEntry)
    {
        Post post = new Post() { entry = textEntry, userId = userId, likes = 0, dateCreated = DateTime.Now };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task likePostAsync(int postId, User user)
    {
        // might not work, just put it here for now. Also allows for inifite likes
        Post temp = await _context.Posts.FirstOrDefaultAsync(t => t.id == postId);
        if(temp != null)
        {
            temp.likes++;
            _context.Posts.Update(temp);
        }
        //_context.Posts.FromSqlRaw($"UPDATE Posts SET likes = likes + 1 WHERE id = {postId}");
        await _context.SaveChangesAsync();
    }

    public async Task deletePostAsync(int postId)
    {
        //_context.Posts.FromSqlRaw($"DELETE from Posts WHERE id={postId}");
        Post temp = await _context.Posts.FirstOrDefaultAsync(t=> t.id == postId);
        if(temp != null)
        {
        _context.Posts.Remove(temp);
        }
        await _context.SaveChangesAsync();
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
        return await _context.Comments.AsNoTracking().ToListAsync();
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

    // Gets all members for a single Band ~Bailey
    public async Task<List<BandMember>> GetAllBandMembers(int bandId)
    {
        return await _context.BandMembers.FromSqlRaw($"Select * From BandMembers Where BandMembers.bandId = {bandId}").ToListAsync();
    }

    // Adds new member to database ~Bailey
    public async Task<BandMember> CreateBandMember(BandMember newMember)
    {
        _context.BandMembers.Add(newMember);
        await _context.SaveChangesAsync();
        return newMember;
    }

    // Removes a member from the database ~Bailey
    public async Task RemoveBandMember(BandMember memberToDelete)
    {
        _context.BandMembers.Remove(memberToDelete);
        await _context.SaveChangesAsync();
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