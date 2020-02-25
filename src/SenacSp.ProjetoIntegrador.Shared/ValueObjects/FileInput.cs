using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.ValueObjects
{
    public class FileInput
    {
        public byte[] Buffer { get; set; }

        public bool HasValue() => Buffer?.Length > 0;
    }
}
