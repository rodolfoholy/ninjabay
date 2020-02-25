using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Products
{
    public class UpdateProductCommand : CreateProductCommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public UpdateProductCommand()
        {
        }
    }
}
