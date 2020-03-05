using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Queries.KeyWord;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Results;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SenacSp.ProjetoIntegrador.Domain.Commands.KeyWord;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/key-words")]
    public class KeyWordsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public KeyWordsController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification)
        {
            _mediator = mediator;
        }
        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<IEnumerable<KeyWordVm>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetKeyWords() => CreateResponse(await _mediator.Send(new GetKeyWordQuery(), CancellationToken.None));

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion

        [HttpPost]
        public async Task<IActionResult> CreateNewKeyWord(CreateKeyWordCommand command) => CreateResponse(await _mediator.Send(command, CancellationToken.None));


    }
}