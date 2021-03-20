using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.ProductImage;
using NinjaBay.Domain.Commands.ProductQA;
using NinjaBay.Domain.Commands.Products;
using NinjaBay.Domain.Contracts.Infra;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Configs;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class ProductCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateProductCommand, CreateProductResult>,
        IRequestHandler<UpdateProductCommand, CreateProductResult>,
        IRequestHandler<ChangeStockQuantityCommand, DefaultResult>,
        IRequestHandler<AddQuestionsAndAnswerProductCommand, DefaultResult>,
        IRequestHandler<InsertProductImageCommand, SaveImageResult>,
        IRequestHandler<DeleteProductImageCommand, DefaultResult>,
        IRequestHandler<ChangeProductStatusCommand, DefaultResult>

    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductQuestionAnswerRepository _productQuestionAnswerRepository;
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IProductRepository productRepository,
            IProductQuestionAnswerRepository productQuestionAnswerRepository,
            IProductImageRepository productImageRepository) : base(uow, notifications)
        {
            _productQuestionAnswerRepository = productQuestionAnswerRepository;
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }

        public async Task<DefaultResult> Handle(AddQuestionsAndAnswerProductCommand command,
            CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var product = await _productRepository.FindAsync(x => x.Id == command.Id);

            if (product == null)
            {
                Notifications.Handle("Não foi possivel encontrar Produto");
                return null;
            }

            var questionsAnswers = new List<ProductQA>();

            foreach (var questionAnswer in command.QuestionsAndAnswers)
                questionsAnswers.Add(ProductQA.New(command.Id, questionAnswer));

            await _productQuestionAnswerRepository.AddRangeAsync(questionsAnswers);

            if (!await CommitAsync()) return result;

            return result;
        }

        public async Task<DefaultResult> Handle(ChangeProductStatusCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var product = await _productRepository.FindAsync(x => x.Id == command.Id);
            if (product == null)
            {
                Notifications.Handle("Produto não encontrado");
                return null;
            }

            product.ChangeStatus();

            _productRepository.Modify(product);


            if (!await CommitAsync()) return null;

            return result;
        }

        public async Task<DefaultResult> Handle(ChangeStockQuantityCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var product = await _productRepository.FindAsync(x => x.Id == command.Id);

            if (product == null)
            {
                Notifications.Handle("Não foi possivel encontrar Produto");
                return null;
            }

            product.ChangeStatus();

            _productRepository.Modify(product);

            if (!await CommitAsync()) return result;

            return result;
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

            result.ProductId = product.Id;

            foreach (var keyWordId in command.KeyWords) product.KeyWords.Add(ProductKeyWord.New(product.Id, keyWordId));

            await _productRepository.AddAsync(product);

            if (!await CommitAsync()) return result;

            return result;
        }

        public async Task<DefaultResult> Handle(DeleteProductImageCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var productImage = await _productImageRepository.FindAsync(x => x.Id == command.Id);

            if (productImage == null)
            {
                Notifications.Handle("Imagem de produto não encontrado");
                return null;
            }
            
            _productImageRepository.Remove(productImage);

            if (!await CommitAsync()) return result;

            return result;
        }

        public async Task<SaveImageResult> Handle(InsertProductImageCommand command,
            CancellationToken cancellationToken)
        {
            var result = new SaveImageResult();

            var product = await _productRepository.FindAsync(x => x.Id == command.ProductId);
            if (product == null)
            {
                Notifications.Handle("Produto Não encotrado");
                return null;
            }

            foreach (var file in command.Images) result.Links.Add(file.url);

            ;
            if (!await CommitAsync()) return result;

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

            if (command.Name != product.Name &&
                await _productRepository.AnyAsync(x => x.Name.ToLower().Equals(command.Name.ToLower())))
            {
                Notifications.Handle("Não é possivel alterar o Nome para o de um produto que já existe");
                return null;
            }

            product.Update(command.Name, command.Description, command.Price, command.Quantity);
            if (command.KeyWords != null) product.SetKeyWords(command.KeyWords);

            result.ProductId = product.Id;

            _productRepository.Modify(product);

            if (!await CommitAsync()) return result;

            return result;
        }
    }
}