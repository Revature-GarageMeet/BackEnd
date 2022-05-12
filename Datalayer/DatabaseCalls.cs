namespace Datalayer;


public class DatabaseCalls : repo
{

    //please sort and comment based on the group's sections if we do ~leo


    //User Login/Registration things
    public async Task<User> createUser(User user){
        return user;
        // throw NotImplementedException ex;
    }

    public async Task loginUser(User user){

    }

    public async Task<Boolean> checkExisting(User user){
        //prob rename that ^ but this is supposed to check if the username's already taken ~leo
        return true;
    }

    public async Task<Boolean> authenticateUser(User user){
        //this one checks if the username and password match  ~leo
        return true;
    }

    //Post Related things
        // get all posts by a User ~ Matthew
        /// <summary>
        /// Gets All the posts by a specific user by user object.
        /// </summary>
        /// <param name="user">User object to find posts for.</param>
        /// <returns>A List of Posts of all the posts by a specific user.</returns>
        public async Task<List<Post>> GetPostsByUserAsync(User user)
        {
            await new Task<List<Post>>();
        }

    //Group/Team things

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