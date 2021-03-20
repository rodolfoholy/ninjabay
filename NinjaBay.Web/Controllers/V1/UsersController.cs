using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.User;
using NinjaBay.Domain.Filters;
using NinjaBay.Domain.Queries.User;
using NinjaBay.Shared.Notifications;

namespace NinjaBay.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ChangeUserStatus(Guid id)
        {
            return CreateResponse(await _mediator.Send(new ChangeUserStatusCommand {Id = id}, CancellationToken.None));
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserByid(Guid id)
        {
            return CreateResponse(await _mediator.Send(new UserByIdQuery {Id = id}, CancellationToken.None));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserFilter filter)
        {
            return CreateResponse(
                await _mediator.Send(new PagedListUserQuery {Filter = filter}, CancellationToken.None));
        }
    }
}