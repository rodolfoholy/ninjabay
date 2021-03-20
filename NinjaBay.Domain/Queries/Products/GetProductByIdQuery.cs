using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Queries
{
    public class GetProductByIdQuery : IRequest<ProductVm>
    {
        [JsonIgnore] public Guid Id { get; set; }
    }
}