using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Models;
using UserService.Shared.Constants;
using UserService.Shared.Utils;

namespace UserService.Controllers;

[Route($"{Constants.ApiUrls.BasePath}/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    // TODO: Replace with actual user data from the database
    readonly List<User> _users = [];

    [HttpPost(Constants.ApiUrls.Auth.Register)]
    public IActionResult Register([FromBody] UserRegister userRegister)
    {
        if (userRegister == null) return BadRequest("User registration data is null.");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var newUser = new User
        {
            Email = userRegister.Email,
            UserName = userRegister.UserName,
            FirstName = userRegister.FirstName,
            LastName = userRegister.LastName,
            PhoneNumber = userRegister.PhoneNumber
        };

        newUser.PasswordHash = Utils.Password.Hash(newUser, userRegister.Password);

        // TODO save the new user to the database instead of the list and assign an ID
        newUser.Id = _users.Count + 1;
        _users.Add(newUser);

        return CreatedAtAction(nameof(Register), new { id = newUser.Id }, newUser);
    }
}