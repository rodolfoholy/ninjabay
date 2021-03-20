using System;
using System.Linq.Expressions;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Filters;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Expression<Func<User, bool>> Where(UserFilter filter);
    }
}