using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class KeyWord
    {
        public Guid Id { get; set; }

        public int Word { get; set; }

        public ICollection<ProductKeyWord> Products { get; set; } = new List<ProductKeyWord>();
    }
}
