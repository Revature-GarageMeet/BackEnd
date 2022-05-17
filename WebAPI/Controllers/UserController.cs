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
    [HttpGet]
    public async Task<User> login(User user)
    {
        return await _db.loginUser(user);
    }

    [HttpGet("Authenticate")]
    public async Task<Boolean> authenticate(User user)
    {
        return await _db.authenticateUser(user);
    }

    [HttpGet("Existing")]
    public async Task<Boolean> existing(User user)
    {
        return await _db.checkExisting(user);
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
}
/*
    post createuser
    get login
    both methods pass into the DatabaseCalls.cs methods and return the user created/logged in
    ~leo
*/