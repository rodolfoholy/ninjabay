using System;
using System.Linq.Expressions;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Filters;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Expression<Func<Product, bool>> Where(ProductFilter filter);
    }
}