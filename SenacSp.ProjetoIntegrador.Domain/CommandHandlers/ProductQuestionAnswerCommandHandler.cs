using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.ProductQA;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
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
    public class ProductQuestionAnswerCommandHandler : BaseCommandHandler,
                IRequestHandler<DeleteProductQACommand, DefaultResult>,
                IRequestHandler<UpdateProductQACommand, DefaultResult>
    {
        private readonly IProductQuestionAnswerRepository _productQuestionAnswerRepository;
        public ProductQuestionAnswerCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IProductQuestionAnswerRepository productQuestionAnswerRepository) : base(uow, notifications)
        {
            _productQuestionAnswerRepository = productQuestionAnswerRepository;
        }
        public async Task<DefaultResult> Handle(DeleteProductQACommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var productQa = await _productQuestionAnswerRepository.FindAsync(x => x.Id == command.Id);

            if (productQa == null)
            {
                Notifications.Handle("Pergunta e resposta não encontrada");
                return null;
            }
            _productQuestionAnswerRepository.Remove(productQa);

            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }

        public async Task<DefaultResult> Handle(UpdateProductQACommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var productQa = await _productQuestionAnswerRepository.FindAsync(x => x.Id == command.Id);

            if (productQa == null)
            {
                Notifications.Handle("Pergunta e resposta não encontrada");
                return null;
            }
            productQa.QuestionAndAnswer.Update(command.QuestionsAndAnswer);

            _productQuestionAnswerRepository.Modify(productQa);

            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }
    }
}
