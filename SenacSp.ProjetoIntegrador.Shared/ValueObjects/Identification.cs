using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Extensions;
using SenacSp.ProjetoIntegrador.Shared.Structs;
using System.ComponentModel;

namespace SenacSp.ProjetoIntegrador.Shared.ValueObjects
{
    public class Identification
    {
        public Identification()
        {
        }

        public Identification(string number,
            EIdentiticationType type) => (Number, Type) = (number, type);

        public string Number { get; set; }

        [JsonIgnore]
        public EIdentiticationType? Type { get; set; }

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
            switch (Type)
            {
                case EIdentiticationType.Cpf:
                    return new Cpf(Number).IsValid;
                    break;
                case EIdentiticationType.Cnpj:
                    return new Cnpj(Number).IsValid;
                case EIdentiticationType.Other:
                    return !string.IsNullOrEmpty(Number);
                    break;
                default:
                    return !string.IsNullOrEmpty(Number);
                    break;
            }
        }

        [ReadOnly(true)]
        [JsonIgnore]
        public string Formatted
        {
            get
            {
                switch (Type)
                {
                    case EIdentiticationType.Cpf:
                        return new Cpf(Number).Format();
                        break;
                    case EIdentiticationType.Cnpj:
                        return new Cnpj(Number).Format();
                    case EIdentiticationType.Other:
                        return Number;
                        break;
                    default:
                        return Number;
                        break;
                }
            }
        }

        public void Update(Identification identification)
        {
            Modify(identification?.Number);
            Type = identification?.Type;
        }
    }
}
