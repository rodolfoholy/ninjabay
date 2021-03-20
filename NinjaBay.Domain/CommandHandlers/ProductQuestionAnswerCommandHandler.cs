using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.ProductQA;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class ProductQuestionAnswerCommandHandler : BaseCommandHandler,
        IRequestHandler<DeleteProductQaCommand, DefaultResult>,
        IRequestHandler<UpdateProductQaCommand, DefaultResult>
    {
        private readonly IProductQuestionAnswerRepository _productQuestionAnswerRepository;

        public ProductQuestionAnswerCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IProductQuestionAnswerRepository productQuestionAnswerRepository) : base(uow, notifications)
        {
            _productQuestionAnswerRepository = productQuestionAnswerRepository;
        }

        public async Task<DefaultResult> Handle(DeleteProductQaCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var productQa = await _productQuestionAnswerRepository.FindAsync(x => x.Id == command.Id);

            if (productQa == null)
            {
                Notifications.Handle("Pergunta e resposta não encontrada");
                return null;
            }

            _productQuestionAnswerRepository.Remove(productQa);

            if (!await CommitAsync()) return result;
            return result;
        }

        public async Task<DefaultResult> Handle(UpdateProductQaCommand command, CancellationToken cancellationToken)
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

            if (!await CommitAsync()) return result;
            return result;
        }
    }
}