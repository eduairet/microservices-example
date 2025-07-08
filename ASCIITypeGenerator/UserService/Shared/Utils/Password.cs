using Microsoft.AspNetCore.Identity;
using UserService.Entities;

namespace UserService.Shared.Utils;

public partial class Utils
{
    public static class Password
    {
        public static string Hash(User user, string password)
        {
            return new PasswordHasher<User>().HashPassword(user, password);
        }
    }
}
