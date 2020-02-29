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
        IRequestHandler<ChangeStockQuantityCommand, DefaultResult>,
        IRequestHandler<AddQuestionsAndAnswerProductCommand, DefaultResult>

    {
        private readonly IProductRepository _productRepository;
        private readonly IProductQuestionAnswerRepository _productQuestionAnswerRepository;
        public ProductCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IProductRepository productRepository, IProductQuestionAnswerRepository productQuestionAnswerRepository) : base(uow, notifications)
        {
            _productQuestionAnswerRepository = productQuestionAnswerRepository;
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

            result.ProductId = product.Id;

            foreach (Guid keyWordId in command.KeyWords)
            {
                product.KeyWords.Add(ProductKeyWord.New(product.Id,keyWordId));
            }

             await _productRepository.AddAsync(product);

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

            if (command.Name != product.Name && await _productRepository.AnyAsync(x => x.Name.ToLower().Equals(command.Name.ToLower())))
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

            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }

        public async Task<DefaultResult> Handle(AddQuestionsAndAnswerProductCommand command, CancellationToken cancellationToken)
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
            {
                questionsAnswers.Add(ProductQA.New(command.Id, questionAnswer));
            }
            await _productQuestionAnswerRepository.AddRangeAsync(questionsAnswers);

            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }
    }
}
