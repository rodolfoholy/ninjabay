using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class ProductQAProjections
    {
        public static ProductQAVm ToVm(this ProductQA productQA)
        {
            return new ProductQAVm
            {
                Id = productQA.Id,
                QuestionAndAnswer = productQA.QuestionAndAnswer
            };
        }

        public static IQueryable<ProductQAVm> ToVm(this IQueryable<ProductQA> query)
        {
            return query.Select(productQA => new ProductQAVm
            {
                Id = productQA.Id,
                QuestionAndAnswer = productQA.QuestionAndAnswer
            });
        }

        public static IEnumerable<ProductQAVm> ToVm(this IEnumerable<ProductQA> query)
        {
            return query.Select(productQA => new ProductQAVm
            {
                Id = productQA.Id,
                QuestionAndAnswer = productQA.QuestionAndAnswer
            });
        }
    }
}