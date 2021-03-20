using System;
using Newtonsoft.Json;

namespace NinjaBay.Domain.Commands.KeyWord
{
    public class UpdateKeyWordCommand : CreateKeyWordCommand
    {
        [JsonIgnore] public Guid Id { get; set; }
    }
}