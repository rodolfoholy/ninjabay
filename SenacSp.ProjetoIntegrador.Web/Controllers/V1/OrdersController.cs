using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Commands.Order;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Infra;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Domain.Queries.Order;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
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
        public async Task<IActionResult> GetOrderByid(Guid id) => CreateResponse(
            await _mediator.Send(new GetOrderByIdQuery {Id = id, SessionUser = _sessionUser}, CancellationToken.None));
    
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
        public async Task<IActionResult> ChangeOrderStatus(Guid id,[FromBody] ChangeOrderStatusCommand command )
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }
    }
}