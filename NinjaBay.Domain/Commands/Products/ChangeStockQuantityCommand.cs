using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.Products
{
    public class ChangeStockQuantityCommand : IRequest<DefaultResult>
    {
        [JsonIgnore] public Guid Id { get; set; }

        public int Quantity { get; set; }
    }
}