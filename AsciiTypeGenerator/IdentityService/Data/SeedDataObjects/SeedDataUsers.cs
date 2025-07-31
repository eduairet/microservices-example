using IdentityService.Entities;
using IdentityService.Shared.Constants;
using IdentityService.Shared.Helpers;

namespace IdentityService.Data.SeedDataObjects;

public class SeedDataUsers(IConfiguration configuration)
{
    public User SuperAdmin()
    {
        var superAdminEmail = new EnvironmentConstants(configuration).SuperAdminEmail;
        var superAdminPassword = new EnvironmentConstants(configuration).SuperAdminPassword;

        var superAdmin = new User
        {
            UserName = nameof(IdentityRolesEnum.SuperAdmin),
            NormalizedUserName = nameof(IdentityRolesEnum.SuperAdmin).ToUpper(),
            Email = superAdminEmail,
            NormalizedEmail = superAdminEmail.ToUpper(),
            RoleId = ((int)IdentityRolesEnum.SuperAdmin).ToString()
        };

        superAdmin.PasswordHash = PasswordHelpers.Hash(superAdmin, superAdminPassword);

        return superAdmin;
    }
}