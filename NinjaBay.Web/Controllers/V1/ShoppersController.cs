using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.Shopper;
using NinjaBay.Domain.Contracts.Infra;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Security;

namespace NinjaBay.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/shoppers")]
    public class ShoppersController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly SessionUser _sessionUser;

        public ShoppersController(IDomainNotification domainNotification, IMediator mediator, ILoggedUser loggedUser) :
            base(domainNotification)
        {
            _mediator = mediator;
            _sessionUser = loggedUser.User;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopper(CreateShopperCommand command)
        {
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> SelfUpdateShopper(UpdateShopperCommand command)
        {
            command.SessionUser = _sessionUser;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }
    }
}