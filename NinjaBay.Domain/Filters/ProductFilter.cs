using System;
using NinjaBay.Shared.Paging;

namespace NinjaBay.Domain.Filters
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