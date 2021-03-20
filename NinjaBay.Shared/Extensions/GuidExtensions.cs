using System;

namespace NinjaBay.Shared.Extensions
{
    public static class GuidExtensions
    {
        public static string HasDigits(this Guid value)
        {
            return value.ToString("N");
        }
    }
}