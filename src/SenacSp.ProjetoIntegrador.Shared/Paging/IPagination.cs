using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.Paging
{
    public interface IPagination
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string SortField { get; set; }
        string SortType { get; set; }
    }
}
