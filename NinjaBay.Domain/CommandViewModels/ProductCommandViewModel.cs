using System;

namespace NinjaBay.Domain.CommandViewModels
{
    public class ProductCommandViewModel
    {
        public Guid ProductId { get; set; }
        public int Qt { get; set; }
    }
}