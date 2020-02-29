using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class KeyWord
    {
        public Guid Id { get; set; }

        public string Word { get; set; }

        public ICollection<ProductKeyWord> Products { get; set; } = new List<ProductKeyWord>();

        public static KeyWord New(string word) => new KeyWord
        {
            Id = Guid.NewGuid(),
            Word = word
        };
    }
}
