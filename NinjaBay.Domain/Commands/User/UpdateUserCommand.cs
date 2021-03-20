using System;
using MediatR;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Enums;

namespace NinjaBay.Domain.Commands.User
{
    public class UpdateUserCommand : IRequest<DefaultResult>
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public EUserType UserType { get; set; }
    }
}