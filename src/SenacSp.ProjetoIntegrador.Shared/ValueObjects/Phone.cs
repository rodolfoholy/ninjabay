using SenacSp.ProjetoIntegrador.Shared.Extensions;
using System;
using System.ComponentModel;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.ValueObjects
{
    public class Phone
    {
        public Phone()
        {

        }

        public Phone(string number)
        {
            Number = number.ToNumber();
        }

        public string Number { get; set; }

        public void Modify(string number) => Number = number;

        [ReadOnly(true)]
        public string Formatted
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Number.ToNumber()))
                {
                    return string.Empty;
                }

                var value = Convert.ToUInt64(Number.ToNumber());

                return Number.Length == 8
                    ? value.ToString(@"0000\-0000")
                    : Number.Length == 9
                    ? value.ToString(@"0\-0000\-0000")
                    : Number.Length == 10
                    ? value.ToString(@"(00) 0000\-0000")
                    : Number.Length == 11
                    ? value.ToString(@"(00) 0\-0000\-0000")
                    : value.ToString();
            }
        }

        public void Update(Phone phone)
        {
            Number = phone?.Number;
        }
    }
}
