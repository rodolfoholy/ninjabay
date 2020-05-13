using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Commands.ShopperAddress;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Infra;
using SenacSp.ProjetoIntegrador.Domain.Queries.KeyWord;
using SenacSp.ProjetoIntegrador.Domain.Queries.ShopperAddress;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/shopper-address")]
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
        public async Task<IActionResult> GetAddresses() => CreateResponse(
            await _mediator.Send(new ListShopperAddressQuery() {SessionUser = _sessionUser}, CancellationToken.None));


        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateShopperAddressCommand command)
        {
            command.SessionUser = _sessionUser;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid id,[FromBody] UpdateShopperAddressCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }
    }
}