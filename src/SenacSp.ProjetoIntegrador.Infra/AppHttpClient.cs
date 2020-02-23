using SenacSp.ProjetoIntegrador.Shared.Configs;
using SenacSp.ProjetoIntegrador.Shared.Infra;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Infra
{
    public class AppHttpClient : IAppHttpClient, IDisposable
    {
        private readonly AppConfig _appConfig;
        private readonly HttpClient _client;

        public AppHttpClient(AppConfig appConfig)
        {
            _appConfig = appConfig;
            _client = new HttpClient();
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task CheckApiStatus()
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{_appConfig.BaseUrl}/api/status");
            var response = await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) => await _client.SendAsync(request);

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<byte[]> DownloadAsync(string url)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request, new HttpCompletionOption { });
            return response.IsSuccessStatusCode ? await response.Content.ReadAsByteArrayAsync() : null;
        }
    }
}
