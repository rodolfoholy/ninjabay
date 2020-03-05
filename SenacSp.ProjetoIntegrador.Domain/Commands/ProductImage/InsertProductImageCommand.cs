using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.ProductImage
{
    public class InsertProductImageCommand : IRequest<SaveImageResult>
    {
        [JsonIgnore]
        public Guid ProductId { get; set; }

        public IEnumerable<FileInput> Files { get; set; } = new List<FileInput>();
    }
}
