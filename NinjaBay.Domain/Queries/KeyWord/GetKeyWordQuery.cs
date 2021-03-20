using System.Collections.Generic;
using MediatR;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Queries.KeyWord
{
    public class GetKeyWordQuery : IRequest<List<KeyWordVm>>
    {
    }
}