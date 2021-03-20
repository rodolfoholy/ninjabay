using System;
using MediatR;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Queries.User
{
    public class UserByIdQuery : IRequest<UserVm>
    {
        public Guid Id { get; set; }
    }
}