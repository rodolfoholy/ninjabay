using SenacSp.ProjetoIntegrador.Shared.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Filters
{
    public class UserFilter : Pagination
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
