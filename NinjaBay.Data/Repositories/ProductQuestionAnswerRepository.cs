using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class ProductQuestionAnswerRepository : Repository<ProductQA>, IProductQuestionAnswerRepository
    {
        public ProductQuestionAnswerRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}