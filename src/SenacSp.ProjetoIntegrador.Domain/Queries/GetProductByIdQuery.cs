using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Queries
{
    public class GetProductByIdQuery : IRequest<ProductVm>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
