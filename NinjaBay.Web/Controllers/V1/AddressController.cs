using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.ShopperAddress;
using NinjaBay.Domain.Contracts.Infra;
using NinjaBay.Domain.Queries.ShopperAddress;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Security;

namespace NinjaBay.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/shopper-address")]
    [Authorize]
    public class AddressController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly SessionUser _sessionUser;

        public AddressController(IDomainNotification domainNotification, IMediator mediator, ILoggedUser loggedUser) :
            base(domainNotification)
        {
            _mediator = mediator;
            _sessionUser = loggedUser.User;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            return CreateResponse(
                await _mediator.Send(new ListShopperAddressQuery {SessionUser = _sessionUser}, CancellationToken.None));
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateShopperAddressCommand command)
        {
            command.SessionUser = _sessionUser;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] UpdateShopperAddressCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }
    }
}