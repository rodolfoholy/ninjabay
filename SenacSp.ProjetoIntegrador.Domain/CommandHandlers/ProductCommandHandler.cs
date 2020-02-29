using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class ProductCommandHandler : BaseCommandHandler, IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        public ProductCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IProductRepository productRepository) : base(uow, notifications)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = new CreateProductResult();

            if (await _productRepository.AnyAsync(x => x.Name.ToLower().Equals(command.Name.ToLower())))
            {
                Notifications.Handle("Produto Com esse nome já Cadastrado");
                return null;
            }
            var product = Product.New(command.Name, command.Description, command.Price, command.Quantity);
            
            await _productRepository.AddAsync(product);

            result.ProductId = product.Id;

            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }
    }
}
