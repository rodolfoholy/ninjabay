using System;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;

namespace SenacSp.ProjetoIntegrador.Domain.Queries.User
{
    public class UserByIdQuery : IRequest<UserVm>
    {
        public Guid Id { get; set; }
    }
}