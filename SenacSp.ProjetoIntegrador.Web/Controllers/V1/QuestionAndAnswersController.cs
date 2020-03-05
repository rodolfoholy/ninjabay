using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Commands.ProductQA;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Results;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questions-and-answers")]
    public class QuestionAndAnswersController : BaseApiController
    {
        private readonly IMediator _mediator;
        public QuestionAndAnswersController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification)
        {
            _mediator = mediator;
        }

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductQA(Guid id, UpdateProductQaCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProductQA(Guid id) => CreateResponse(await _mediator.Send(new DeleteProductQaCommand { Id = id }, CancellationToken.None));
    }
}



