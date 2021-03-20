using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.ProductImage
{
    public class DeleteProductImageCommand : IRequest<DefaultResult>
    {
        [JsonIgnore] public Guid Id { get; set; }
    }
}