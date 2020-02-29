using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Queries
{
    public class PagedProductListQuery : IRequest<PagedList<ProductVm>>
    {
        public ProductFilter Filter { get; set; }
    }
}
