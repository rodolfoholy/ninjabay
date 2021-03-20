using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Queries.Order
{
    public class GetOrderByIdQuery : IRequest<OrderVm>
    {
        public Guid Id { get; set; }

        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}