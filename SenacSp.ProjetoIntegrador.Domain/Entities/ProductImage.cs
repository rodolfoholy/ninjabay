using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; private set; }

        public static ProductImage New(Guid productId, string imagePath) => new ProductImage
        {
            Id = Guid.NewGuid(),
            ImagePath = imagePath,
            ProductId = productId
        };
    }
}
