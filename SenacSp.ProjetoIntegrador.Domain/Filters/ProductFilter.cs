using SenacSp.ProjetoIntegrador.Shared.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Filters
{
    public class ProductFilter : Pagination
    {
        public string Search { get; set; }

        public decimal? MinValue { get; set; }

        public decimal? MaxValue { get; set; }
    }
}
