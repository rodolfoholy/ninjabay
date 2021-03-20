using System;
using Newtonsoft.Json;

namespace NinjaBay.Domain.Commands.Products
{
    public class UpdateProductCommand : CreateProductCommand
    {
        [JsonIgnore] public Guid Id { get; set; }
    }
}