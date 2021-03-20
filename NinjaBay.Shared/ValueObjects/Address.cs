using System;
using System.ComponentModel;
using System.Linq;

namespace NinjaBay.Shared.ValueObjects
{
    public class Address
    {
        public string PlaceName { get; set; }

        public string Number { get; set; }


        public string Complement { get; set; }


        public string District { get; set; }


        public string ZipCode { get; set; }


        public string City { get; set; }


        public string State { get; set; }

        public string Country { get; set; }

        [ReadOnly(true)]
        public string FormattedZipCode
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ZipCode)) return string.Empty;
                if (ZipCode.Trim().Length == 8)
                {
                    var value = Convert.ToUInt64(ZipCode);
                    return value.ToString(@"00000\-000");
                }

                return ZipCode;
            }
        }


        public string Complete
        {
            get
            {
                var value = new[]
                {
                    PlaceName, Number, Complement, District, FormattedZipCode,
                    !string.IsNullOrWhiteSpace(ZipCode) && !string.IsNullOrWhiteSpace(State) ? $"{City}-{State}" :
                    !string.IsNullOrWhiteSpace(ZipCode) ? City : ""
                };

                return string.Join(", ", value.Where(x => !string.IsNullOrWhiteSpace(x)));
            }
        }
    }
}