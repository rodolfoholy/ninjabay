using Microsoft.EntityFrameworkCore;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
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

            predicate = !filter.MinValue.HasValue
                ? predicate
                : predicate.And(x => x.Price >= filter.MinValue.Value);
            
            return predicate;

        }
    }
}
