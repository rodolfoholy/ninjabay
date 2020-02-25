using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class ProductQA
    {
        public Guid Id { get; set; }

        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }

        public string Question { get; private set; }

        public string Answer { get; private set; }

        public static ProductQA New(Guid productId, string question, string answer) => new ProductQA
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            Answer = answer,
            Question = question
        };
    }
}
