using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Projections;
using NinjaBay.Domain.Queries.KeyWord;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Notifications;

namespace NinjaBay.Domain.QueryHandler
{
    public class KeyWordQueryHandler : BaseQueryHandler, IRequestHandler<GetKeyWordQuery, List<KeyWordVm>>
    {
        private readonly IKeyWordRepository _keyWordRepository;

        public KeyWordQueryHandler(IDomainNotification notifications, IKeyWordRepository keyWordRepository) : base(
            notifications)
        {
            _keyWordRepository = keyWordRepository;
        }

        public async Task<List<KeyWordVm>> Handle(GetKeyWordQuery query, CancellationToken cancellationToken)
        {
            return _keyWordRepository.ListAsNoTracking().OrderBy(x => x.Word).ToVm().ToList();
        }
    }
}