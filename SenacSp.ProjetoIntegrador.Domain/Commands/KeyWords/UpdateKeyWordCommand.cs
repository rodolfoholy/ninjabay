using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.KeyWords
{
   public class UpdateKeyWordCommand : CreateKeyWordCommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
