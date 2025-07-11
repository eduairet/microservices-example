using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Models.User;
using UserService.Shared.Constants;
using UserService.Shared.Helpers;

namespace UserService.Controllers;

[ApiController]
[Route($"{Constants.ApiRoutes.BasePath}/[controller]")]
public class AuthController(
    IConfiguration configuration,
    UserManager<User> userManager) : ControllerBase
{
    [HttpPost(Constants.ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegister)
    {
        if (userRegister is null) return BadRequest(Constants.ErrorMessages.EmptyUserRegistration);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userExists = await userManager.FindByEmailAsync(userRegister.Email);

        if (userExists is not null)
            return BadRequest(Constants.ErrorMessages.UserAlreadyExists);

        try
        {
            var newUser = userRegister.ToUser();
            var newUserResult = await userManager.CreateAsync(newUser, userRegister.Password);

            if (newUserResult.Succeeded)
                return CreatedAtAction(nameof(Register), new { id = newUser.Id }, newUser);

            foreach (var error in newUserResult.Errors)
                ModelState.AddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(Constants.ApiRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
    {
        if (userLogin == null) return BadRequest(Constants.ErrorMessages.EmptyUserLogin);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var user = await userManager.FindByEmailAsync(userLogin.Email);

            if (user is null) return NotFound(Constants.ErrorMessages.UserNotFound);

            if (!Helpers.Password.Verify(user, userLogin.Password))
                return Unauthorized(Constants.ErrorMessages.InvalidCredentials);

            var passwordResult = await userManager.CheckPasswordAsync(user, userLogin.Password);

            if (!passwordResult) return Unauthorized(Constants.ErrorMessages.InvalidCredentials);

            var token = await Helpers.Jwt.CreateToken(user, configuration, userManager);

            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}