using System;

namespace NinjaBay.Domain.ViewModels
{
    public class ProductOrderVm
    {
        public Guid Id { get; set; }

        public ProductVm Product { get; set; }

        public decimal PaidValue { get; set; }

        public int Quantity { get; set; }
    }
}