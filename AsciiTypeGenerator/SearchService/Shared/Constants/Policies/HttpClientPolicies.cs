using System.Net;
using Polly;
using Polly.Extensions.Http;

namespace SearchService.Shared.Constants.Policies;

public static class HttpClientPolicies
{
    public static IAsyncPolicy<HttpResponseMessage> RetryWhenNotFound() => HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
        .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));
}