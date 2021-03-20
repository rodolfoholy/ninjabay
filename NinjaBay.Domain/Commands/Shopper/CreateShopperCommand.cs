using MediatR;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Commands.Shopper
{
    public class CreateShopperCommand : IRequest<SaveShopperResult>
    {
        public string Email { get; set; }

        public Identification Cpf { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public string Password { get; set; }
    }
}