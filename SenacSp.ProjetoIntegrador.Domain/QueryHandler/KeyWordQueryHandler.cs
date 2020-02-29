using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Projections;
using SenacSp.ProjetoIntegrador.Domain.Queries.KeyWord;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Domain.QueryHandler
{
    public class KeyWordQueryHandler : BaseQueryHandler, IRequestHandler<GetKeyWordQuery, List<KeyWordVm>>
    {
        private readonly IKeyWordRepository _keyWordRepository;
        public KeyWordQueryHandler(IDomainNotification notifications, IKeyWordRepository keyWordRepository) : base(notifications)
        {
            _keyWordRepository = keyWordRepository;
        }

        public async Task<List<KeyWordVm>> Handle(GetKeyWordQuery query, CancellationToken cancellationToken) => _keyWordRepository.ListAsNoTracking().OrderBy(x => x.Word).ToVm().ToList();
    }
}
