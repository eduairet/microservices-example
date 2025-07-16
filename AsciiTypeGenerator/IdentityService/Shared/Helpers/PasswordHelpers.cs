using IdentityService.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Shared.Helpers;

public static class PasswordHelpers
{
    public static string Hash(User user, string password)
    {
        return new PasswordHasher<User>().HashPassword(user, password);
    }

    public static bool Verify(User user, string password)
    {
        if (user is null || string.IsNullOrEmpty(user.PasswordHash)) return false;

        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
}