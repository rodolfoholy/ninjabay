using SenacSp.ProjetoIntegrador.Shared.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Filters
{
    public class ProductFilter : Pagination
    {
        public string Name { get; set; }

        public Guid? KeyWordId { get; set; }

        public bool? IsActive { get; set; } = true;
        public decimal? MinValue { get; set; }

        public decimal? MaxValue { get; set; }
    }
}
