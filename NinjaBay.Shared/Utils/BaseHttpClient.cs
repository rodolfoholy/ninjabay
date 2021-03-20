using System.Net.Http;

namespace NinjaBay.Shared.Utils
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