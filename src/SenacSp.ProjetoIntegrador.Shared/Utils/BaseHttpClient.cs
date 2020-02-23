using System.Net.Http;

namespace SenacSp.ProjetoIntegrador.Shared.Utils
{
    public class BaseHttpClient
    {
        public readonly HttpClient Client;

        public BaseHttpClient()
        {
            Client = new HttpClient();
        }
    }
}