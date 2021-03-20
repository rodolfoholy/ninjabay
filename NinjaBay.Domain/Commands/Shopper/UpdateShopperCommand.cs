using MediatR;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.Shopper
{
    public class UpdateShopperCommand : BaseCommandWithSessionUser, IRequest<SaveShopperResult>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}