    using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly repo _db;
    public UserController(repo db)
    {
        _db = db;
    }


    [HttpGet]
    public User login(User user)
    {
        return new User();
        // return _db.loginUser(user);
    }

    [HttpPost]
    public void createUser(User user){
        // _db.createUser(user);
        // probably make this actually return the user rather than just adding to db. also make everything ^^ async
    }
}
/*
    post createuser
    get login
    ~leo
*/