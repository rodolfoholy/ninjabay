using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace NinjaBay.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string FormatPhone(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var number = Regex.Replace(value, @"[^0-9]", "");

            value = number.Length == 10
                ? Convert.ToUInt64(number).ToString(@"00\-00000000")
                : number.Length == 11
                    ? Convert.ToUInt64(number).ToString(@"00\-000000000")
                    : value;

            return value;
        }

        public static string ToNumber(this string value)
        {
            return string.IsNullOrWhiteSpace(value?.Trim())
                ? ""
                : Regex.Replace(value, @"[^0-9]", "");
        }


        public static string ToBase64Hash(this string value)
        {
            using (var hashData = SHA256.Create())
            {
                var data = hashData.ComputeHash(Encoding.ASCII.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public static string FormatCpfCnpj(this string value)
        {
            var result = "";

            if (string.IsNullOrWhiteSpace(value)) return result;

            var number = value.ToNumber();

            result = number.Length == 11
                ? Convert.ToUInt64(number).ToString(@"000\.000\.000\-00")
                : number.Length == 14
                    ? Convert.ToUInt64(number).ToString(@"00\.000\.000\/0000\-00")
                    : result;

            return result;
        }

        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }

        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        public static string ReplaceSpecial(this string value)
        {
            return Regex.Replace(value, @"[\\/]", "_");
        }

        public static string ToBase64Key(this string value)
        {
            return value.ToBase64().ReplaceSpecial();
        }

        public static string GetExtension(this string value)
        {
            return Path.GetExtension(value);
        }

        public static string RemoveSpaces(this string value)
        {
            value = value.Replace(" ", "").Trim();
            return value;
        }

        public static T ToEnum<T>(this string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }

        public static bool IsNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value?.Trim());
        }

        public static string GenerateCode(this string value, int length)
        {
            var random = new Random();
            var characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = new StringBuilder(length);
            for (var i = 0; i < length; i++) result.Append(characters[random.Next(characters.Length)]);

            return result.ToString();
        }
    }
}