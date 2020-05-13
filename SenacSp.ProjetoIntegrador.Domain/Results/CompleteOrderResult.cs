using System.Collections.Generic;
using SenacSp.ProjetoIntegrador.Domain.CommandViewModels;

namespace SenacSp.ProjetoIntegrador.Domain.Results
{
    public class CompleteOrderResult
    {
        public List<ProductCommandViewModel> Itens { get; set; }

        public string Message { get; set; }
    }
}