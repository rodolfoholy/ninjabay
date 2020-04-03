using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Domain.Commands.ProductImage;
using SenacSp.ProjetoIntegrador.Domain.Commands.ProductQA;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Domain.Queries;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Paging;
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

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<SaveImageResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion  

        [HttpPost("images/{id:guid}")]
        public async Task<IActionResult> SaveProductImages(Guid id, [FromBody] InsertProductImageCommand command)
        {
            command.ProductId = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [HttpDelete("images/{productImageId:guid}")]
        public async Task<IActionResult> DeleteProductImage(Guid productImageId) => CreateResponse(await _mediator.Send(new DeleteProductImageCommand { Id = productImageId }, CancellationToken.None));

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion 

        [HttpPost("questions-answers/{idProduct:guid}")]
        public async Task<IActionResult> SaveProductQuestionAndAnswers(Guid idProduct,AddQuestionsAndAnswerProductCommand command)
        {
            command.Id = idProduct;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }


        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<CreateProductResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion 

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id,[FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));

        }

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion
        [HttpPut("stock/{id:guid}")]
        public async Task<IActionResult> UpdateProductQuantity([FromBody]ChangeStockQuantityCommand command, Guid id)
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
        public async Task<IActionResult> ChangeProductStatus(Guid id)
            => CreateResponse(await _mediator.Send(new ChangeProductStatusCommand { Id = id }, CancellationToken.None));

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<ProductVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
            => CreateResponse(await _mediator.Send(new GetProductByIdQuery { Id = id }, CancellationToken.None));

        #region SwaggerDoc
        [ProducesResponseType(typeof(EnvelopDataResult<PagedList<ProductVm>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int)HttpStatusCode.InternalServerError)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilter filter)
            => CreateResponse(await _mediator.Send(new PagedProductListQuery { Filter = filter}, CancellationToken.None));
    }
}
