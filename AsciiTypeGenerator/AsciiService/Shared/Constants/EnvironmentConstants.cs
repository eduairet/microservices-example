namespace AsciiService.Shared.Constants;

public class EnvironmentConstants(IConfiguration configuration)
{
    #region Database Settings

    public string ConnectionString => configuration.GetConnectionString("DefaultConnection")
                                      ?? throw new NullReferenceException(
                                          Messages.Messages.Error.KeyNotSet("DefaultConnection"));

    #endregion

    #region Service URLs

    public string IdentityServiceUrl => configuration["IDENTITY_SERVICE_URL"]
                                        ?? throw new NullReferenceException(
                                            Messages.Messages.Error.KeyNotSet("IDENTITY_SERVICE_URL"));

    #endregion

    #region RabbitMQ Settings
    public string RabbitMqHost => configuration["RABBIT_MQ_HOST"]
                                 ?? throw new NullReferenceException(
                                     Messages.Messages.Error.KeyNotSet("RABBIT_MQ_HOST"));

    public string RabbitMqUsername => configuration["RABBIT_MQ_USERNAME"] ?? "guest";
    public string RabbitMqPassword => configuration["RABBIT_MQ_PASSWORD"] ?? "guest";

    #endregion
}