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

    public string DatabasePort => configuration["DB_PORT"]
                                  ?? throw new NullReferenceException(
                                      ErrorMessages.KeyNotSet("DB_PORT"));

    #endregion
}