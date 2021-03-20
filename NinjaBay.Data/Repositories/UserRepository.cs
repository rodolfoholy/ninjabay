using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Filters;
using NinjaBay.Shared.Utils;

namespace NinjaBay.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ECommerceDataContext context) : base(context)
        {
        }

        public Expression<Func<User, bool>> Where(UserFilter filter)
        {
            var predicate = PredicateBuilder.True<User>();

            predicate = string.IsNullOrWhiteSpace(filter.Name)
                ? predicate
                : predicate.And(x => EF.Functions.Like(x.Nome.ToLower(), $"%{filter.Name.ToLower()}%"));

            predicate = string.IsNullOrWhiteSpace(filter.Email)
                ? predicate
                : predicate.And(x => EF.Functions.Like(x.Email.ToLower(), $"%{filter.Email.ToLower()}%"));

            return predicate;
        }
    }
}