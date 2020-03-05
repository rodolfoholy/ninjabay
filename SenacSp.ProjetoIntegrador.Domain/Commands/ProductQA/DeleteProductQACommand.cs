using System;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.ProductQA
{
    public class DeleteProductQaCommand : IRequest<DefaultResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
