//using Microsoft.AspNetCore.Mvc;


//namespace WebAPI.Controllers;
//[Route("[controller]")]
//[ApiController]
//public class UserController : ControllerBase
//{
//    private readonly DBInterface _db;
//    public UserController(DBInterface db)
//    {
//        _db = db;
//    }
//    [HttpGet]
//    public async Task<User> login(User user)
//    {
//        return await _db.loginUser(user);
//    }
//    [HttpPost]
//    public async Task<User> createUser(User user)
//    {
//        return await _db.createUser(user);
//    }
//}
///*
//    post createuser
//    get login
//    both methods pass into the DatabaseCalls.cs methods and return the user created/logged in
//    ~leo
//*/