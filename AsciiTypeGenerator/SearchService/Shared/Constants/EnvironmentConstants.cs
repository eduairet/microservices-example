namespace SearchService.Shared.Constants;

public class EnvironmentConstants(IConfiguration configuration)
{
    #region Database Settings

    public string ConnectionString => configuration.GetConnectionString("MongoDbConnection")
                                      ?? throw new NullReferenceException(
                                          ErrorMessages.KeyNotSet("MongoDbConnection"));

    public string DatabaseName => configuration["DB_NAME"]
                                  ?? throw new NullReferenceException(
                                      ErrorMessages.KeyNotSet("DB_NAME"));

    #endregion


    #region Services

    public string AsciiServiceUrl => configuration["ASCII_SERVICE_URL"]
                                     ?? throw new NullReferenceException(
                                         ErrorMessages.KeyNotSet("ASCII_SERVICE_URL"));

    #endregion

    #region RabbitMQ Settings
    public string RabbitMqHost => configuration["RABBIT_MQ_HOST"]
                                 ?? throw new NullReferenceException(
                                     ErrorMessages.KeyNotSet("RABBIT_MQ_HOST"));

    public string RabbitMqUsername => configuration["RABBIT_MQ_USERNAME"] ?? "guest";
    public string RabbitMqPassword => configuration["RABBIT_MQ_PASSWORD"] ?? "guest";

    #endregion

}