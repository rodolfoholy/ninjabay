using System;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.Queries.Order
{
    public class GetOrderByIdQuery : IRequest<OrderVm>
    {
        public Guid Id { get; set; }
        
        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}