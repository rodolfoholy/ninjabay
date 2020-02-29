using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
{
    public class KeyWordRepository : Repository<KeyWord>, IKeyWordRepository
    {
        public KeyWordRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}
