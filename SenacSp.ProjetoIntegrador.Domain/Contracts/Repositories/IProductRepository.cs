using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Expression<Func<Product, bool>> Where(ProductFilter filter);
    }
}
