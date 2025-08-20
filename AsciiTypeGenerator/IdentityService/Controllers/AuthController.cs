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
    UserManager<User> userManager,
    ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost(ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegister)
    {
        logger.LogInformation("Registering user with email: {Email}", userRegister?.Email);

        try
        {
            if (userRegister is null) return BadRequest(ErrorMessages.EmptyUserRegistration);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userExists = await userManager.FindByEmailAsync(userRegister.Email);

            if (userExists is not null)
                return BadRequest(ErrorMessages.UserAlreadyExists);

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
            logger.LogError(ex, "An error occurred while registering user with email: {Email}\n{Exception}",
                userRegister?.Email, ex.Message);
            return StatusCode(500, ErrorMessages.InternalServerError);
        }
        finally
        {
            logger.LogInformation("Finished registering user with email: {Email}", userRegister?.Email);
        }
    }

    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
    {
        logger.LogInformation("User login attempt with email: {Email}", userLogin?.Email);

        try
        {
            if (userLogin == null) return BadRequest(ErrorMessages.EmptyUserLogin);

            if (!ModelState.IsValid) return BadRequest(ModelState);

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
            logger.LogError(ex, "An error occurred during login attempt with email: {Email}\n{Exception}",
                userLogin?.Email, ex.Message);
            return StatusCode(500, ErrorMessages.InternalServerError);
        }
        finally
        {
            logger.LogInformation("Finished login attempt with email: {Email}", userLogin?.Email);
        }
    }
}