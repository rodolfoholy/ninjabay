using MediatR;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Enums;

namespace NinjaBay.Domain.Commands.User
{
    public class CreateUserCommand : IRequest<DefaultResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public EUserType UserType { get; set; }
    }
}