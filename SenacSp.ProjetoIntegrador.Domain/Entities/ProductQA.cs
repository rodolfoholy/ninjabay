using SenacSp.ProjetoIntegrador.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class ProductQA
    {
        public Guid Id { get; private set; }

        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }

        public QuestionAnswer QuestionAndAnswer { get; set; }

        public static ProductQA New(Guid productId, QuestionAnswer questionAnswer) => new ProductQA
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            QuestionAndAnswer = questionAnswer
        };
    }
}
