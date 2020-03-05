using MediatR;
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
using SenacSp.ProjetoIntegrador.Domain.Commands.KeyWord;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class KeyWordCommandHandler : BaseCommandHandler , 
        IRequestHandler<CreateKeyWordCommand,DefaultResult>
    {
        private readonly IKeyWordRepository _keyWordRepository;
        public KeyWordCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IKeyWordRepository keyWordRepository) : base(uow, notifications)
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
            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }
    }
}
