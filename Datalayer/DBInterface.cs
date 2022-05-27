namespace Datalayer
{
    public interface DBInterface
    {
        //DOCUMENT WHAT EACH METHOD DOES HERE

        //User Login/Registration things ~Mo's Group
        /// <summary>
        /// Creates the User, first uses checkExisting to see if username is taken or not yet, throws an exception if already existing
        /// </summary>
        /// <param name="user">User to Create</param>
        /// <returns>User Created</returns>
        Task<User> createUser(User user);
        /// <summary>
        /// Logs in a user, uses authenticateUser to check if matching, throws an exception if it isn't found
        /// </summary>
        /// <param name="user">User to Login</param>
        /// <returns>User Logged In</returns>
        Task<User> loginUser(string user);
        /// <summary>
        /// Returns if the username is already taken
        /// </summary>
        /// <param name="user">User to check</param>
        /// <returns>True if exists, False if doesn't</returns>
        Task<User> updateUser(User user);
        Task<Boolean> checkExisting(string username);
        /// <summary>
        /// Returns if username and password match
        /// </summary>
        /// <param name="user">User to check</param>
        /// <returns>True if matched, False if doesn't</returns>
        Task<Boolean> authenticateUser(User user);


        //************************************************ Post Related things ************************************************ 
        /// <summary>
        /// Returns all posts from a user
        /// </summary>
        Task<List<Post>> GetPostsByUserAsync(User user);
        /// <summary>
        /// Gets the post from both Post and User ID for liking a post
        /// </summary>
        /// <param name="postID">Post ID that the user is liking</param>
        /// <returns></returns>
        Task<Post> GetPostByPostID(int postID);
        /// <summary>
        /// Returns all posts from a user's id
        /// </summary>
        Task<List<Post>> getPostbyUserIdAsync(int userId);
        /// <summary>
        /// Returns all posts from a band's id
        /// </summary>
        Task<List<Post>> getPostbyBandIdAsync(int bandId);
        /// <summary>
        /// Posts for a band's Id
        /// </summary>
        Task postForBandAsync(int bandId, string textEntry, string postType);
        /// <summary>
        /// Posts for a user
        /// </summary>
        Task postForUserAsync(User user, string textEntry, string postType);
        /// <summary>
        /// Posts for a user's Id
        /// </summary>
        Task postForUserIdAsync(int userId, string textEntry, string postType);
        /// <summary>
        /// Like post, not sure how this should really be done - maybe we really do need a like table????
        /// </summary>
        Task LikePostAsync(int postId, int user);
        Task UnlikePostAsync(int postId, int user);
        Task<int> GetPostLikesAsync(int postId);
        Task<List<LikedPosts>> GetUserLikesAsync(int userId);

        Task deletePostAsync(int postId);
        /// <summary>
        ///     Author: Jose
        ///     Context: Creates comment in database
        /// </summary>
        /// <param name="commentToAdd"></param>
        /// <returns></returns>
        Task AddCommentAsync(Comment commentToAdd);
        /// <summary>
        ///     Author: Jose
        ///     Context: Gets comment by comment id from database
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns>Returns comment respective to the id</returns>
        Task<Comment> GetCommentAsync(int commentId);
        /// <summary>
        ///     Author: Jose
        ///     Context: Gets all comments from post id from database
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Returns list of comments respective to post id</returns>
        Task<List<Comment>> GetAllCommentsAsync(int postId);
        /// <summary>
        ///     Author: Jose
        ///     Context: Updates the comment (likes, entry)
        /// </summary>
        /// <param name="commentToUpdate"></param>
        /// <returns>Returns the updated comment</returns>
        Task<Comment> UpdateCommentAsync(Comment commentToUpdate);

        //Group/Team things
        //Should we differentiate b/t bandId and bandmemberId? -Arrion
        Task<Band> CreateBand(Band newBand);
        /// <summary>
        /// Creates new band
        /// </summary>

        Task<List<Band>> GetBands(int bandId);
        /// <summary>
        /// Gets all created bands
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns>A list of band names </return>

        Task DeleteBand(int bandId);
        /// <summary>
        /// Deletes a band
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>

        /// <summary>
        /// Gets every bandmember that is apart of a specific Band
        /// </summary>
        /// <param name="bandId">Unique id attached to a band</param>
        /// <returns>List of every bandmember record attached to a specific bandId</returns>
        Task<List<BandMember>> GetAllBandMembers(int bandId);
        /// <summary>
        /// Adds a new BandMember record to the BandMember DB Table ~Bailey
        /// </summary>
        /// <param name="newMember">A BandMember object to be added</param>
        /// <returns>The newly created bandMember object</returns>
        Task<BandMember> CreateBandMember(BandMember newMember);
        /// <summary>
        /// Removes a BandMember record from the BandMember DB Table ~Bailey
        /// </summary>
        /// <param name="memberToDelete">A BandMember object to be used for record removal</param>
        Task RemoveBandMember(BandMember memberToDelete);
        /// <summary>
        /// Gets a list of band names
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        Task<List<string>> GetAllBandNames(int bandId);
        /// <summary>
        /// Gets all band records in the database
        /// </summary>
        /// <returns>List containing every Band record</returns>
        Task<List<Band>> GetAllBands();
        Task UpdateBand(Band changeBand);
    }
}