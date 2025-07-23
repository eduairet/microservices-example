using IdentityService.Entities;
using IdentityService.Models.User;
using IdentityService.Shared.Constants;
using IdentityService.Shared.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class AuthController(
    IConfiguration configuration,
    UserManager<User> userManager) : ControllerBase
{
    [HttpPost(ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegister)
    {
        if (userRegister is null) return BadRequest(ErrorMessages.EmptyUserRegistration);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userExists = await userManager.FindByEmailAsync(userRegister.Email);

        if (userExists is not null)
            return BadRequest(ErrorMessages.UserAlreadyExists);

        try
        {
            var newUser = userRegister.ToEntity();
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

    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
    {
        if (userLogin == null) return BadRequest(ErrorMessages.EmptyUserLogin);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var user = await userManager.FindByEmailAsync(userLogin.Email);

            if (user is null) return NotFound(ErrorMessages.UserNotFound);

            if (!PasswordHelpers.Verify(user, userLogin.Password))
                return Unauthorized(ErrorMessages.InvalidCredentials);

            var passwordResult = await userManager.CheckPasswordAsync(user, userLogin.Password);

            if (!passwordResult) return Unauthorized(ErrorMessages.InvalidCredentials);

            var token = await JwtHelpers.CreateToken(user, configuration, userManager);

            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}