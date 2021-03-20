using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class ProductImageProjection
    {
        public static ProductImageVm ToVm(this ProductImage productImage)
        {
            return new ProductImageVm
            {
                Id = productImage.Id,
                ImageFullPath = productImage.ImagePath
            };
        }

        public static IQueryable<ProductImageVm> ToVm(this IQueryable<ProductImage> query)
        {
            return query.Select(productImage => new ProductImageVm
            {
                Id = productImage.Id,
                ImageFullPath = productImage.ImagePath
            });
        }

        public static IEnumerable<ProductImageVm> ToVm(this IEnumerable<ProductImage> query)
        {
            return query.Select(productImage => new ProductImageVm
            {
                Id = productImage.Id,
                ImageFullPath = productImage.ImagePath
            });
        }
    }
}