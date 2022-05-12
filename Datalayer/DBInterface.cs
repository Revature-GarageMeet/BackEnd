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
        Task<User> loginUser(User user);
        /// <summary>
        /// Returns if the username is already taken
        /// </summary>
        /// <param name="user">User to check</param>
        /// <returns>True if exists, False if doesn't</returns>
        Task<Boolean> checkExisting(User user);
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
        Task postForBandAsync(int bandId, string textEntry);
        /// <summary>
        /// Posts for a user
        /// </summary>
        Task postForUserAsync(User user, string textEntry);
        /// <summary>
        /// Posts for a user's Id
        /// </summary>
        Task postForUserIdAsync(int userId, string textEntry);
        /// <summary>
        /// Like post, not sure how this should really be done - maybe we really do need a like table????
        /// </summary>
        Task likePostAsync(int postId, User user);


        //Group/Team things
    }
}