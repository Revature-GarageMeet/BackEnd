using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DBInterface _db;
    public UserController(DBInterface db)
    {
        _db = db;
    }
    [HttpGet("Login/{user}")]
    public async Task<User> login(string user)
    {
        return await _db.loginUser(user);
    }

    [HttpGet("Authenticate")]
    public async Task<Boolean> authenticate(User user)
    {
        return await _db.authenticateUser(user);
    }

    [HttpGet("Existing/{username}")]
    public async Task<Boolean> existing(string username)
    {
        return await _db.checkExisting(username);
    }

    [HttpPost]
    public async Task<User> createUser(User user)
    {
        return await _db.createUser(user);
    }

    [HttpPut]
    public async Task<User> updateUser(User user)
    {
        return await _db.updateUser(user);
    }
    [HttpGet("GetUserByID/{userId}")]
    public async Task<User> GetUserByIDAsync(int userId)
    {
        return await _db.GetUserByIDAsync(userId);
    }
}
/*
   post createuser
   get login
   both methods pass into the DatabaseCalls.cs methods and return the user created/logged in
   ~leo
*/