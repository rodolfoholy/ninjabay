using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.ProductQA;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Results;

namespace NinjaBay.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questions-and-answers")]
    public class QuestionAndAnswersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public QuestionAndAnswersController(IDomainNotification domainNotification, IMediator mediator) : base(
            domainNotification)
        {
            _mediator = mediator;
        }

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductQA(Guid id, UpdateProductQaCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProductQA(Guid id) =>
            CreateResponse(await _mediator.Send(new DeleteProductQaCommand {Id = id}, CancellationToken.None));
    }
}