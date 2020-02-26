using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.Extensions
{
    public static class GuidExtensions
    {
        public static string HasDigits(this Guid value) => value.ToString("N");
    }
}