using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.Order;
using NinjaBay.Domain.Contracts.Infra;
using NinjaBay.Domain.Filters;
using NinjaBay.Domain.Queries.Order;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Security;

namespace NinjaBay.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly SessionUser _sessionUser;


        public OrdersController(IDomainNotification domainNotification, IMediator mediator, ILoggedUser loggedUser) :
            base(domainNotification)
        {
            _mediator = mediator;
            _sessionUser = loggedUser.User;
        }

        [HttpPost]
        public async Task<IActionResult> FinalizeOrder([FromBody] FinalizeOrderCommand command)
        {
            command.SessionUser = _sessionUser;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderByid(Guid id)
        {
            return CreateResponse(
                await _mediator.Send(new GetOrderByIdQuery {Id = id, SessionUser = _sessionUser},
                    CancellationToken.None));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] OrderFilter filter)
        {
            return _sessionUser.UserType == "Shopper"
                ? CreateResponse(await _mediator.Send(
                    new PagedOrderListQuery {SessionUser = _sessionUser, Filter = filter}, CancellationToken.None))
                : CreateResponse(await _mediator.Send(
                    new PagedAllOrdersListQuery {SessionUser = _sessionUser, Filter = filter}, CancellationToken.None));
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> ChangeOrderStatus(Guid id, [FromBody] ChangeOrderStatusCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }
    }
}