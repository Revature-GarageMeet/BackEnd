namespace Datalayer
{
    public interface DBInterface
    {
        //DOCUMENT WHAT EACH METHOD DOES HERE

        //User Login/Registration things ~Mo's Group
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> createUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> loginUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Boolean> checkExisting(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Boolean> authenticateUser(User user);

        //Post Related things


        //Group/Team things
    }
}