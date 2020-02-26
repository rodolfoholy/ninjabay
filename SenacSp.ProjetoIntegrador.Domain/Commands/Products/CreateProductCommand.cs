using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Products
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string Name { get;  set; }
        public int? Quantity { get; set; }
        public IEnumerable<string> KeyWords { get; set; } = new List<string>();
        public decimal? Price { get;  set; }
        public string Description { get; set; }
    }
}
