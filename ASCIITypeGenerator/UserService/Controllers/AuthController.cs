using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Models.User;
using UserService.Shared.Constants;
using UserService.Shared.Utils;

namespace UserService.Controllers;

[Route($"{Constants.ApiUrls.BasePath}/[controller]")]
[ApiController]
public class AuthController(
    IConfiguration configuration,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : ControllerBase
{
    [HttpPost(Constants.ApiUrls.Auth.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
    {
        if (userRegister is null) return BadRequest(Constants.ErrorMessages.EmptyUserRegistration);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            // TODO Implement Automapper
            var newUser = new User
            {
                Email = userRegister.Email,
                UserName = userRegister.UserName,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                PhoneNumber = userRegister.PhoneNumber,
                AvatarUrl = userRegister.AvatarUrl,
            };

            newUser.PasswordHash = Utils.Password.Hash(newUser, userRegister.Password);

            var newUserResult = await userManager.CreateAsync(newUser, userRegister.Password);

            if (newUserResult.Succeeded == false)
            {
                foreach (var error in newUserResult.Errors)
                    ModelState.AddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            const string roleName = nameof(UserRoles.User);
            var roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
                return BadRequest(Constants.ErrorMessages.UserRoleNotFound);

            await userManager.AddToRoleAsync(newUser, roleName);

            return CreatedAtAction(nameof(Register), new { id = newUser.Id }, newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(Constants.ApiUrls.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
    {
        if (userLogin == null) return BadRequest(Constants.ErrorMessages.EmptyUserLogin);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var user = await userManager.FindByEmailAsync(userLogin.Email);

            if (user is null) return NotFound(Constants.ErrorMessages.UserNotFound);

            if (!Utils.Password.Verify(user, userLogin.Password))
                return Unauthorized(Constants.ErrorMessages.InvalidCredentials);

            var passwordResult = await userManager.CheckPasswordAsync(user, userLogin.Password);

            if (!passwordResult) return Unauthorized(Constants.ErrorMessages.InvalidCredentials);

            var token = Utils.Jwt.CreateToken(user, configuration, userManager);

            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}