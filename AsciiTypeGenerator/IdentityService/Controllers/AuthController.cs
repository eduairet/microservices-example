using IdentityService.Entities;
using IdentityService.Models.User;
using IdentityService.Shared.Constants;
using IdentityService.Shared.Constants.Messages;
using IdentityService.Shared.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class AuthController(
    IConfiguration configuration,
    UserManager<User> userManager,
    ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost(ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegister)
    {
        logger.LogInformation(Messages.Info.RegisteringUserLog, userRegister?.Email);

        try
        {
            if (userRegister is null) return BadRequest(Messages.Error.EmptyUserRegistration);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userExists = await userManager.FindByEmailAsync(userRegister.Email);

            if (userExists is not null)
                return BadRequest(Messages.Error.UserAlreadyExists);

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
            logger.LogError(ex, Messages.Error.UserRegisteringErrorLog,
                userRegister?.Email, ex.Message);
            return StatusCode(500, Messages.Error.InternalServerError);
        }
        finally
        {
            logger.LogInformation(Messages.Info.RegisteredUserLog, userRegister?.Email);
        }
    }

    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
    {
        logger.LogInformation(Messages.Info.LoginAttemptUserLog, userLogin?.Email);

        try
        {
            if (userLogin == null) return BadRequest(Messages.Error.EmptyUserLogin);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await userManager.FindByEmailAsync(userLogin.Email);

            if (user is null) return NotFound(Messages.Error.UserNotFound);

            if (!PasswordHelpers.Verify(user, userLogin.Password))
                return Unauthorized(Messages.Error.InvalidCredentials);

            var passwordResult = await userManager.CheckPasswordAsync(user, userLogin.Password);

            if (!passwordResult) return Unauthorized(Messages.Error.InvalidCredentials);

            var token = await JwtHelpers.CreateToken(user, configuration, userManager);

            return Ok(token);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, Messages.Error.UserLoginErrorLog,
                userLogin?.Email, ex.Message);
            return StatusCode(500, Messages.Error.InternalServerError);
        }
        finally
        {
            logger.LogInformation(Messages.Info.LoggedInUserLog, userLogin?.Email);
        }
    }
}