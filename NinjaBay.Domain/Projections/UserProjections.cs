using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class UserProjections
    {
        public static UserVm ToVm(this User user)
        {
            return new UserVm
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active,
                Nome = user.Nome,
                Type = user.Type
            };
        }

        public static IQueryable<UserVm> ToVm(this IQueryable<User> query)
        {
            return query.Select(user => new UserVm
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active,
                Nome = user.Nome,
                Type = user.Type
            });
        }

        public static IEnumerable<UserVm> ToVm(this IEnumerable<User> query)
        {
            return query.Select(user => new UserVm
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active,
                Nome = user.Nome,
                Type = user.Type
            });
        }
    }
}