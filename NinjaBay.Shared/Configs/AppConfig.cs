namespace NinjaBay.Shared.Configs
{
    public class AppConfig
    {
        public string Domain { get; set; }
        public string BaseUrl { get; set; }

        //public string HangfireCookie { get; set; }

        public bool HttpsOnly { get; set; }

        public string ConnectionString { get; set; }
    }
}