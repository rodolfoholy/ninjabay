using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.ProductQA
{
    public class DeleteProductQaCommand : IRequest<DefaultResult>
    {
        [JsonIgnore] public Guid Id { get; set; }
    }
}