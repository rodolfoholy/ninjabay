using System.ComponentModel;
using Newtonsoft.Json;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.Extensions;
using NinjaBay.Shared.Structs;

namespace NinjaBay.Shared.ValueObjects
{
    public class Identification
    {
        public Identification()
        {
        }

        public Identification(string number,
            EIdentiticationType type)
        {
            (Number, Type) = (number, type);
        }

        public string Number { get; set; }

        [JsonIgnore] public EIdentiticationType? Type { get; set; }

        [ReadOnly(true)]
        [JsonIgnore]
        public string Formatted
        {
            get
            {
                return Type switch
                {
                    EIdentiticationType.Cpf => new Cpf(Number).Format(),
                    EIdentiticationType.Cnpj => new Cnpj(Number).Format(),
                    EIdentiticationType.Other => Number,
                    _ => Number
                };
            }
        }

        public void Modify(string number)
        {
            switch (Type)
            {
                case EIdentiticationType.Cpf:
                case EIdentiticationType.Cnpj:
                    Number = number?.ToNumber();
                    break;
                case EIdentiticationType.Other:
                    Number = number;
                    break;
                default:
                    Number = number;
                    break;
            }
        }

        public bool IsValid()
        {
            return Type switch
            {
                EIdentiticationType.Cpf => new Cpf(Number).IsValid,
                EIdentiticationType.Cnpj => new Cnpj(Number).IsValid,
                EIdentiticationType.Other => !string.IsNullOrEmpty(Number),
                _ => !string.IsNullOrEmpty(Number)
            };
        }

        public void Update(Identification identification)
        {
            Modify(identification?.Number);
            Type = identification?.Type;
        }
    }
}