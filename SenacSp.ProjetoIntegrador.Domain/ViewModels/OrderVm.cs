using System;
using System.Collections.Generic;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Extensions;

namespace SenacSp.ProjetoIntegrador.Domain.ViewModels
{
    public class OrderVm
    {
        public Guid Id { get;  set; }

        public long OrderIdentifier { get;  set; }

        public DateTime CreatedAt { get; set; }

        public ShopperAddressVm ShippingAddress { get;  set; }

        public EPaymentMethod PaymentMethod { get;  set; }

        public string PaymentMethodDescription => PaymentMethod.Description();

        public EPaymentStatus PaymentStatus { get;  set; }
        public string PaymentStatusDescription => PaymentStatus.Description();
        public decimal Total { get; set; }
        
        public IEnumerable<ProductOrderVm> Products { get;  set; } = new List<ProductOrderVm>();
    }
}