using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public QuestionAndAnswersController(IDomainNotification domainNotification) : base(domainNotification)
        {
        }
        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion 

        [HttpPost("{idProduct:guid}")]
        public async Task<IActionResult> SaveProductQuestionAndAnswers(AddQuestionsAndAnswerProductCommand command, Guid idProduct) 
        {
            command.Id = idProduct;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [HttpGet]
        public IActionResult Get() => Ok("teste12345");
    }
}



