using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Commands.User;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Domain.Queries.User;
using SenacSp.ProjetoIntegrador.Shared.Notifications;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
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
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand command) => CreateResponse(await _mediator.Send(command,CancellationToken.None));
        
        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command,CancellationToken.None));
        }
        [Authorize]

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ChangeUserStatus( Guid id) => CreateResponse(await _mediator.Send(new ChangeUserStatusCommand{Id = id}, CancellationToken.None));
        [Authorize]

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserByid( Guid id) => CreateResponse(await _mediator.Send(new UserByIdQuery{Id = id},CancellationToken.None));

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserFilter filter)
            => CreateResponse(await _mediator.Send(new PagedListUserQuery{Filter = filter}, CancellationToken.None));
    }
}