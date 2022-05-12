﻿using System.Linq;
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
        if (await checkExisting(user))
        {
            //User Already Exists, throw an exception or something
            //THIS NEEDS TO BE DONE STILL
            return user;
        }
        else
        {
            //prob need to add other default values to user still
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
    public async Task<User> loginUser(User auth)
    {
        if (await authenticateUser(auth))
        {
            //If username and password match then give the user back
            return await _context.Users.FirstOrDefaultAsync(user => user.username == auth.username && user.password == auth.password);
        }
        else
        {
            //if fail then throw an exception or something
            return auth;
        }
    }
    public async Task<Boolean> checkExisting(User auth)
    {
        return await _context.Users.AnyAsync(user => user.username == auth.username);
    }
    public async Task<Boolean> authenticateUser(User auth)
    {
        return await _context.Users.AnyAsync(user => user.username == auth.username && user.password == auth.password);
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