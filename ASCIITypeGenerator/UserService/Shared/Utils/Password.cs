using Microsoft.AspNetCore.Identity;
using UserService.Entities;

namespace UserService.Shared.Utils;

public static partial class Utils
{
    public static class Password
    {
        public static string Hash(User user, string password)
        {
            return new PasswordHasher<User>().HashPassword(user, password);
        }

        public static bool Verify(User user, string password)
        {
            if (user is null || string.IsNullOrEmpty(user.PasswordHash)) return false;

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}