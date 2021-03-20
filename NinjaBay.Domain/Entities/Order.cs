using System;
using System.Collections.Generic;
using NinjaBay.Shared.Enums;

namespace NinjaBay.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }

        public long OrderIdentifier { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Shopper Shopper { get; private set; }

        public Guid ShopperId { get; private set; }

        public ShopperAddress ShippingAddress { get; private set; }

        public Guid ShippingAddressId { get; private set; }

        public EPaymentMethod PaymentMethod { get; private set; }

        public EPaymentStatus PaymentStatus { get; private set; }

        public decimal Total { get; private set; }

        public ICollection<ProductOrder> Products { get; } = new List<ProductOrder>();

        public void SetTotal(decimal total)
        {
            Total = total;
        }

        public static Order New(EPaymentMethod paymentMethod, Guid shopperId, Guid shippingId)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ShopperId = shopperId,
                ShippingAddressId = shippingId,
                PaymentStatus = EPaymentStatus.WaitingApproval,
                PaymentMethod = paymentMethod
            };
        }

        public void ChangeOrderStatus(EPaymentStatus status)
        {
            PaymentStatus = status;
        }
    }
}