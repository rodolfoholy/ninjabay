using MediatR;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Queries.KeyWord
{
    public class GetKeyWordQuery : IRequest<List<KeyWordVm>>
    {
    }
}
