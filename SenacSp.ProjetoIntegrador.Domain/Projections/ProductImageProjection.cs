using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class ProductImageProjection
    {
        public static ProductImageVm ToVm(this ProductImage productImage) => new ProductImageVm
        {
            Id = productImage.Id,
            ImageFullPath = productImage.ImagePath
        };

        public static IQueryable<ProductImageVm> ToVm(this IQueryable<ProductImage> query) => query.Select(productImage => new ProductImageVm
        {
            Id = productImage.Id,
            ImageFullPath = productImage.ImagePath
        });

        public static IEnumerable<ProductImageVm> ToVm(this IEnumerable<ProductImage> query) => query.Select(productImage => new ProductImageVm
        {
            Id = productImage.Id,
            ImageFullPath = productImage.ImagePath
        });
    }
}
