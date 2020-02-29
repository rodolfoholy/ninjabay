using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
   public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public ICollection<ProductQA> QuestionsAndAnswers { get; private set; } = new List<ProductQA>();
        public ICollection<ProductKeyWord> KeyWords { get; private set; } = new List<ProductKeyWord>();
        public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();

        public bool IsAvailabe(Product product) => product.Quantity > 0 && product.IsActive;

        public static Product New(string name, string description,decimal? price = null, int? quantity = null) => new Product
        {
            Id = Guid.NewGuid(),
            IsActive = true,
            Description = description,
            Name = name,
            Price = price.Value,
            Quantity = quantity.Value
        };

    }
}
