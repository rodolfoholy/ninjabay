using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.KeyWord;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class KeyWordCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateKeyWordCommand, DefaultResult>
    {
        private readonly IKeyWordRepository _keyWordRepository;

        public KeyWordCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IKeyWordRepository keyWordRepository) : base(uow, notifications)
        {
            _keyWordRepository = keyWordRepository;
        }

        public async Task<DefaultResult> Handle(CreateKeyWordCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            if (await _keyWordRepository.AnyAsync(x => x.Word.ToLower().Equals(command.Word.ToLower())))
            {
                Notifications.Handle("Palava Chave já Cadastrada");
                return null;
            }

            await _keyWordRepository.AddAsync(KeyWord.New(command.Word));
            if (!await CommitAsync()) return result;
            return result;
        }
    }
}