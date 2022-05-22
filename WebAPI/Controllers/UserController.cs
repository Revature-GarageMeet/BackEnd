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
   [HttpGet("UserLogin/{username}/{password}")]
   public async Task<User> login(string username, string password)
   {
       return await _db.loginUser(username, password);
   }
   [HttpPost("Create/{username}/{password}/{email}")]
   public async Task<User> createUser(string username, string password, string email)
   {
       return await _db.createUser(username, password, email);
   }
}
/*
   post createuser
   get login
   both methods pass into the DatabaseCalls.cs methods and return the user created/logged in
   ~leo
*/