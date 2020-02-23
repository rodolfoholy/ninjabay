using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.Configs
{
    public class AwsS3Config
    {
        public string AccessKeyId { get; set; }

        public string SecretAccessKey { get; set; }

        public string Region { get; set; }

        public string BucketName { get; set; }

        public string AvatarsPath { get; set; }

        public string ClientsLogosPath { get; set; }

        public string BucketBaseUrl { get; set; }

        public string BuildAvatarPath(string key) => $"{BucketBaseUrl}/{AvatarsPath}/{key}";

        public string BuildClientLogoPath(string key) => $"{AvatarsPath}/{key}";
    }
}