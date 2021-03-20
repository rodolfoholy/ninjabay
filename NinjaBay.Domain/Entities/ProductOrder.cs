using System;

namespace NinjaBay.Domain.Entities
{
    public class ProductOrder
    {
        public Guid Id { get; private set; }

        public Product Product { get; set; }

        public Guid ProductId { get; private set; }

        public decimal PaidPrice { get; private set; }

        public int Quantity { get; private set; }

        public Order Order { get; private set; }

        public Guid OrderId { get; private set; }

        public static ProductOrder New(Guid productId, int qtd, decimal paidPrice)
        {
            return new ProductOrder
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Quantity = qtd,
                PaidPrice = paidPrice
            };
        }
    }
}