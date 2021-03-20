using System;
using MediatR;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.User
{
    public class ChangeUserStatusCommand : IRequest<DefaultResult>
    {
        public Guid Id { get; set; }
    }
}