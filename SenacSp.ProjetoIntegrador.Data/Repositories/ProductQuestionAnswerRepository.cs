using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
{
    public class ProductQuestionAnswerRepository : Repository<ProductQA>, IProductQuestionAnswerRepository
    {
        public ProductQuestionAnswerRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}
