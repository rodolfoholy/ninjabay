using System;

namespace NinjaBay.Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; private set; }

        public static ProductImage New(Guid productId, string imagePath)
        {
            return new ProductImage
            {
                Id = Guid.NewGuid(),
                ImagePath = imagePath,
                ProductId = productId
            };
        }
    }
}