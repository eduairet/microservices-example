using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UserService.Entities;

namespace UserService.Shared.Helpers;

public static partial class Helpers
{
    public static class Jwt
    {
        public static async Task<string> CreateToken(User user, IConfiguration configuration,
            UserManager<User> userManager)
        {
            if (user is null || string.IsNullOrEmpty(user.Id) || string.IsNullOrEmpty(user.Email) ||
                string.IsNullOrEmpty(user.UserName))
                throw new NullReferenceException(Constants.Constants.ErrorMessages.InvalidJwtUser(nameof(user)));

            var (jwtKey, jwtIssuer, jwtAudience) = GetJwtSettings(configuration);

            var roles = await userManager.GetRolesAsync(user);
            var rolesSelect = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Sub, user.UserName),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JTI is the JWT ID
                    new(JwtRegisteredClaimNames.Email, user.Email),
                    new(ClaimTypes.NameIdentifier, user.Id)
                }
                .Union(rolesSelect)
                .Union(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Constants.Constants.Jwt.TokenExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            var (jwtKey, jwtIssuer, jwtAudience) = GetJwtSettings(configuration);

            return new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = jwtAudience,
                ValidateIssuer = true,
                ValidIssuer = jwtIssuer,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ClockSkew = TimeSpan.Zero
            };
        }

        private static (string jwtKey, string jwtIssuer, string jwtAudience) GetJwtSettings(
            IConfiguration configuration)
        {
            var jwtKey = configuration[Constants.Constants.Jwt.JwtKeyKey] ??
                         throw new InvalidOperationException(
                             Constants.Constants.ErrorMessages.KeyNotSet(Constants.Constants.Jwt.JwtKeyKey));
            var jwtIssuer = configuration[Constants.Constants.Jwt.JwtIssuerKey] ??
                            throw new InvalidOperationException(
                                Constants.Constants.ErrorMessages.KeyNotSet(Constants.Constants.Jwt.JwtIssuerKey));
            var jwtAudience = configuration[Constants.Constants.Jwt.JwtAudienceKey] ??
                              throw new InvalidOperationException(
                                  Constants.Constants.ErrorMessages.KeyNotSet(Constants.Constants.Jwt.JwtAudienceKey));

            return (jwtKey, jwtIssuer, jwtAudience);
        }
    }
}