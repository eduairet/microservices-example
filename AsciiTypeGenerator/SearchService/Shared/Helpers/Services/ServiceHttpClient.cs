namespace SearchService.Shared.Helpers.Services;

public class ServiceHttpClient(IConfiguration configuration, string serviceUrl)
{
    public IConfiguration Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    protected readonly HttpClient HttpClient = new();
    protected readonly string ServiceUrl = serviceUrl;
}