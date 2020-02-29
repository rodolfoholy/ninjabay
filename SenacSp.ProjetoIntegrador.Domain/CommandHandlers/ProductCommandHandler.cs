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
    public class ProductCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateProductCommand, CreateProductResult>,
        IRequestHandler<UpdateProductCommand, CreateProductResult>,
        IRequestHandler<ChangeStockQuantityCommand, DefaultResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductKeyWordRepository _productKeyWordRepository;

        public ProductCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IProductRepository productRepository, IProductKeyWordRepository productKeyWordRepository) : base(uow, notifications)
        {
            _productKeyWordRepository = productKeyWordRepository;
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

            foreach (Guid keyWordId in command.KeyWords)
            {
                await _productKeyWordRepository.AddAsync(ProductKeyWord.New(product.Id, keyWordId));
            };

            result.ProductId = product.Id;

            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }

        public async Task<CreateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var result = new CreateProductResult();

            var product = await _productRepository.FindAsync(x => x.Id == command.Id);

            if (product == null)
            {
                Notifications.Handle("Não foi possivel encontrar Produto");
                return null;                
            }

            if ( command.Name != product.Name && await _productRepository.AnyAsync(x => x.Name.ToLower().Equals(command.Name.ToLower())))
            {
                Notifications.Handle("Não é possivel alterar o Nome para o de um produto que já existe");
                return null;
            }
            product.Update(command.Name, command.Description, command.Price, command.Quantity);
            if (command.KeyWords != null)
            {
                product.SetKeyWords(command.KeyWords);
            }
            _productRepository.Modify(product);

            if (!await CommitAsync())
            {
                return result;
            }
            return result;

        }

        public Task<DefaultResult> Handle(ChangeStockQuantityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
