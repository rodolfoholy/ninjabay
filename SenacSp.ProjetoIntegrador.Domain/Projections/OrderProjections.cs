using System.Collections.Generic;
using System.Linq;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class OrderProjections
    {
        public static OrderVm ToVm(this Order order) => new OrderVm()
        {
            Id = order.Id,
            Products = order.Products.ToVm(),
            Total = order.Total,
            CreatedAt = order.CreatedAt,
            OrderIdentifier = order.OrderIdentifier,
            PaymentMethod = order.PaymentMethod,
            PaymentStatus = order.PaymentStatus,
            ShippingAddress = order.ShippingAddress.ToVm()
        };

        public static IQueryable<OrderVm> ToVm(this IQueryable<Order> query) => query.Select(
            order => new OrderVm()
            {
                Id = order.Id,
                Products = order.Products != null ? order.Products.ToVm(): null,
                Total = order.Total,
                CreatedAt = order.CreatedAt,
                OrderIdentifier = order.OrderIdentifier,
                PaymentMethod = order.PaymentMethod,
                PaymentStatus = order.PaymentStatus,
                ShippingAddress = order.ShippingAddress != null ?order.ShippingAddress.ToVm(): null
            });
        
        public static IEnumerable<OrderVm> ToVm(this IEnumerable<Order> query) => query.Select(
            order => new OrderVm()
            {
                Id = order.Id,
                Products = order.Products.ToVm(),
                Total = order.Total,
                CreatedAt = order.CreatedAt,
                OrderIdentifier = order.OrderIdentifier,
                PaymentMethod = order.PaymentMethod,
                PaymentStatus = order.PaymentStatus,
                ShippingAddress = order.ShippingAddress.ToVm()
            });
    }
}