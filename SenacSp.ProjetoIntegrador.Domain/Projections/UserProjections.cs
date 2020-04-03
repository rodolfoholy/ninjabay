using System.Collections.Generic;
using System.Linq;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class UserProjections
    {

        public static UserVm ToVm(this User user) => new UserVm
        {
            Id = user.Id,
            Email = user.Email,
            Active = user.Active,
            Nome = user.Nome,
            Type = user.Type
        };

        public static IQueryable<UserVm> ToVm(this IQueryable<User> query) => query.Select(user => new UserVm
        {
            Id = user.Id,
            Email = user.Email,
            Active = user.Active,
            Nome = user.Nome,
            Type = user.Type            
        });
        public static IEnumerable<UserVm> ToVm(this IEnumerable<User> query) => query.Select(user => new UserVm
        {
            Id = user.Id,
            Email = user.Email,
            Active = user.Active,
            Nome = user.Nome,
            Type = user.Type            
        });
        
    }
}