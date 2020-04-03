using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Expression<Func<User, bool>> Where(UserFilter filter);
    }
}
