using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Commands.ProductImage
{
    public class InsertProductImageCommand : IRequest<SaveImageResult>
    {
        [JsonIgnore] public Guid ProductId { get; set; }

        public IEnumerable<ImageInput> Images { get; set; } = new List<ImageInput>();
    }
}