using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Filters;
using NinjaBay.Shared.Utils;

namespace NinjaBay.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDataContext context) : base(context)
        {
        }

        public Expression<Func<Product, bool>> Where(ProductFilter filter)
        {
            var predicate = PredicateBuilder.True<Product>();

            predicate = string.IsNullOrEmpty(filter.Name)
                ? predicate
                : predicate.And(x => EF.Functions.Like(x.Name.ToLower(), $"%{filter.Name.ToLower()}"));

            predicate = !filter.KeyWordId.HasValue
                ? predicate
                : predicate.And(x => x.KeyWords.Count(y => y.KeyWordId.Equals(filter.KeyWordId)) > 0);

            predicate = !filter.MaxValue.HasValue
                ? predicate
                : predicate.And(x => x.Price <= filter.MaxValue.Value);

            predicate = predicate.And(x => x.IsActive == filter.IsActive);

            predicate = !filter.MinValue.HasValue
                ? predicate
                : predicate.And(x => x.Price >= filter.MinValue.Value);

            return predicate;
        }
    }
}