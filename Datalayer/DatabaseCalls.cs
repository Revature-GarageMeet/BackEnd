namespace Datalayer;


public class DatabaseCalls : DBInterface
{

    //please sort and comment based on the group's sections if we do ~leo
    //CODE ONLY, DOCUMENTATION (of what it does) GOES IN THE INTERFACE


    //User Login/Registration things
    public async Task<User> createUser(User user){
        return user;
        // throw NotImplementedException ex;
    }

    public async Task<User> loginUser(User user){
        return user;
    }

    public async Task<Boolean> checkExisting(User user){
        //prob rename that ^ but this is supposed to check if the username's already taken ~leo
        //used for
        return true;
    }

    public async Task<Boolean> authenticateUser(User user){
        //this one checks if the username and password match  ~leo
        return true;
    }

    //Post Related things


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