using System.Collections.Generic;
using System.Linq;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class ProductOrderProjections
    {
        public static ProductOrderVm ToVm(this ProductOrder productOrder) => new ProductOrderVm
        {
            Id = productOrder.Id,
            Product = productOrder.Product.ToVm(),
            Quantity = productOrder.Quantity,
            PaidValue = productOrder.PaidPrice
        };

        public static IQueryable<ProductOrderVm> ToVm(this IQueryable<ProductOrder> query) => query.Select(
            productOrder => new ProductOrderVm()
            {
                Id = productOrder.Id,
                Product = productOrder.Product.ToVm(),
                Quantity = productOrder.Quantity,
                PaidValue = productOrder.PaidPrice
            });
        
        public static IEnumerable<ProductOrderVm> ToVm(this IEnumerable<ProductOrder> query) => query.Select(
            productOrder => new ProductOrderVm()
            {
                Id = productOrder.Id,
                Product = productOrder.Product.ToVm(),
                Quantity = productOrder.Quantity,
                PaidValue = productOrder.PaidPrice
            });
        
    }
}