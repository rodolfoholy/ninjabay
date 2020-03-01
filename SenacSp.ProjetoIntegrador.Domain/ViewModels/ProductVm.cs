using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.ViewModels
{
   public class ProductVm
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public bool IsAvailable { get;  set; }
        public int Quantity { get;  set; }
        public decimal Price { get;  set; }
        public IEnumerable<KeyWordVm> KeyWords { get; set; } = new List<KeyWordVm>();
    }
}
