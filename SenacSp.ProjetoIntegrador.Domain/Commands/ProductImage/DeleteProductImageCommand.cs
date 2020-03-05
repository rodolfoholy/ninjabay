using System;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.ProductImage
{
    public class DeleteProductImageCommand : IRequest<DefaultResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
