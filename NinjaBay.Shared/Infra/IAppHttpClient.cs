using System.Net.Http;
using System.Threading.Tasks;

namespace NinjaBay.Shared.Infra
{
    public interface IAppHttpClient
    {
        Task<byte[]> DownloadAsync(string url);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
        Task CheckApiStatus();
    }
}