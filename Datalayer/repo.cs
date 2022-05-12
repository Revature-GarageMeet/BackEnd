namespace Datalayer
{
    public interface repo
    {
        //do we actually need this? yall decide but look at dbc and add everything there to here and please sort and comment based on the group's sections if we do ~leo
        //nvm we need this, can rename this if yall want but fix it in the controller if you do


        //User Login/Registration things

        /*Post Related things
        ~GetPostbyUser/GetPostbyUserID -depends whether we want to take in User.ID or User | for profile
        ~GetPostbyBandID? | for band profile
        ~GetPost - load first 50 ordered by date created? | for public lookup, may need to specify public/private posts, will show both band and user posts
        ~CreatePostforSelf - adds self userid to post
        ~CreatePostforBand - adds band bandid to post
        
        */
        //Group/Team things

        // get all posts by a User ~ Matthew
        Task<List<Post>> GetPostsByUserAsync(User user);
    }
}