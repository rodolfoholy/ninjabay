using Microsoft.EntityFrameworkCore;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ECommerceDataContext context) : base(context)
        {

        }

        public Expression<Func<User, bool>> Filter(UserFilter filter)
        {
            var predicate = PredicateBuilder.True<User>();

            predicate = string.IsNullOrWhiteSpace(filter.Name)
                ? predicate
                : predicate.And(x => EF.Functions.Like((x.Nome).ToLower(), $"%{filter.Name.ToLower()}%"));

            predicate = string.IsNullOrWhiteSpace(filter.Email)
                ? predicate
                : predicate.And(x => EF.Functions.Like((x.Email).ToLower(), $"%{filter.Email.ToLower()}%"));

            return predicate;
        }
    }
}
