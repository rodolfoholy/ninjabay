using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NinjaBay.Domain.Commands.ProductImage;
using NinjaBay.Domain.Commands.ProductQA;
using NinjaBay.Domain.Commands.Products;
using NinjaBay.Domain.Filters;
using NinjaBay.Domain.Queries;
using NinjaBay.Domain.Results;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Paging;
using NinjaBay.Shared.Results;

namespace NinjaBay.Web.Controllers.V1
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

        [ProducesResponseType(typeof(EnvelopDataResult<CreateProductResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
            => CreateResponse(await _mediator.Send(command, CancellationToken.None));

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<SaveImageResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpPost("images/{id:guid}")]
        public async Task<IActionResult> SaveProductImages(Guid id, [FromBody] InsertProductImageCommand command)
        {
            command.ProductId = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        [HttpDelete("images/{productImageId:guid}")]
        public async Task<IActionResult> DeleteProductImage(Guid productImageId)
        {
            return CreateResponse(await _mediator.Send(new DeleteProductImageCommand {Id = productImageId},
                CancellationToken.None));
        }

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpPost("questions-answers/{idProduct:guid}")]
        public async Task<IActionResult> SaveProductQuestionAndAnswers(Guid idProduct,
            AddQuestionsAndAnswerProductCommand command)
        {
            command.Id = idProduct;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }


        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<CreateProductResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            return CreateResponse(await _mediator.Send(command, CancellationToken.None));
        }

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<DefaultResult>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpPut("stock/{id:guid}")]
        public async Task<IActionResult> UpdateProductQuantity([FromBody] ChangeStockQuantityCommand command, Guid id)
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ChangeProductStatus(Guid id)
            => CreateResponse(await _mediator.Send(new ChangeProductStatusCommand {Id = id}, CancellationToken.None));

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<ProductVm>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
            => CreateResponse(await _mediator.Send(new GetProductByIdQuery {Id = id}, CancellationToken.None));

        #region SwaggerDoc

        [ProducesResponseType(typeof(EnvelopDataResult<PagedList<ProductVm>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(EnvelopResult), (int) HttpStatusCode.InternalServerError)]

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilter filter)
            => CreateResponse(await _mediator.Send(new PagedProductListQuery {Filter = filter},
                CancellationToken.None));
    }
}