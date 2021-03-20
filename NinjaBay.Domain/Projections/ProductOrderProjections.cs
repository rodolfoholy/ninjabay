using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class ProductOrderProjections
    {
        public static ProductOrderVm ToVm(this ProductOrder productOrder)
        {
            return new ProductOrderVm
            {
                Id = productOrder.Id,
                Product = productOrder.Product.ToVm(),
                Quantity = productOrder.Quantity,
                PaidValue = productOrder.PaidPrice
            };
        }

        public static IQueryable<ProductOrderVm> ToVm(this IQueryable<ProductOrder> query)
        {
            return query.Select(
                productOrder => new ProductOrderVm
                {
                    Id = productOrder.Id,
                    Product = productOrder.Product.ToVm(),
                    Quantity = productOrder.Quantity,
                    PaidValue = productOrder.PaidPrice
                });
        }

        public static IEnumerable<ProductOrderVm> ToVm(this IEnumerable<ProductOrder> query)
        {
            return query.Select(
                productOrder => new ProductOrderVm
                {
                    Id = productOrder.Id,
                    Product = productOrder.Product.ToVm(),
                    Quantity = productOrder.Quantity,
                    PaidValue = productOrder.PaidPrice
                });
        }
    }
}