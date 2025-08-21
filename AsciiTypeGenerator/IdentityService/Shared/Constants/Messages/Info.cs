namespace IdentityService.Shared.Constants.Messages;

public static partial class Messages
{
    public static partial class Info
    {
        #region Configuration

        public const string DatabaseSuperAdminAlreadyExists = "Database already has SuperAdmin user. Skipping seeding.";

        #endregion

        #region API

        public const string RegisteringUserLog = "Registering user with email {Email}.";
        public const string RegisteredUserLog = "User with email {Email} registered successfully.";
        public const string LoginAttemptUserLog = "User login attempt with email: {Email}";
        public const string LoggedInUserLog = "User with email {Email} logged in successfully.";

        #endregion
    }
}