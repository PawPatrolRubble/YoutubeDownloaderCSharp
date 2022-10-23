using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace YoutubeDownloader.Core.Utils;

internal static class Http
{
    public static HttpClient Client { get; } = new(handler:CreateHttpClientHandler())
    {
        DefaultRequestHeaders =
        {
            // Required by some of the services we're using
            UserAgent =
            {
                new ProductInfoHeaderValue(
                    "YoutubeDownloader",
                    typeof(Http).Assembly.GetName().Version?.ToString(3)
                )
            }
        }
    };

    private static HttpClientHandler CreateHttpClientHandler()
    {
        var webProxy = new WebProxy()
        {
            Address = new System.Uri("socks5://127.0.0.1:1088")
        };
        return new HttpClientHandler()
        {
            Proxy = webProxy
        };
    }
}