using System;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Entities
{
    public class ProductQA
    {
        public Guid Id { get; private set; }

        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }

        public QuestionAnswer QuestionAndAnswer { get; private set; }

        public static ProductQA New(Guid productId, QuestionAnswer questionAnswer)
        {
            return new ProductQA
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                QuestionAndAnswer = questionAnswer
            };
        }
    }
}