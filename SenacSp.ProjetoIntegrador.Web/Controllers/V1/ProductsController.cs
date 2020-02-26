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
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ProductsController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification)
        {
            _mediator = mediator;
        }

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<CreateProductResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion 
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
            => CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}