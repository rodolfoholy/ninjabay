using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.Auth;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Results;

namespace NinjaBay.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification)
        {
            _mediator = mediator;
        }


        #region swaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<AuthResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), 422)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpPost]
        public async Task<IActionResult> Authorize([FromBody] AuthCommand command) =>
            CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}