using System.Collections.Generic;
using NinjaBay.Domain.CommandViewModels;

namespace NinjaBay.Domain.Results
{
    public class CompleteOrderResult
    {
        public List<ProductCommandViewModel> Itens { get; set; }

        public string Message { get; set; }
    }
}