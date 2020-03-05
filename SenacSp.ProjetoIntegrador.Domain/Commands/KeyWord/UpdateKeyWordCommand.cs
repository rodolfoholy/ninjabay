using System;
using Newtonsoft.Json;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.KeyWord
{
   public class UpdateKeyWordCommand : CreateKeyWordCommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
