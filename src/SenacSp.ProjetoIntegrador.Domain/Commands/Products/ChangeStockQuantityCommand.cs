using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Products
{
   public class ChangeStockQuantityCommand : IRequest<DefaultResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public int Quantity { get; set; }
    }
}
