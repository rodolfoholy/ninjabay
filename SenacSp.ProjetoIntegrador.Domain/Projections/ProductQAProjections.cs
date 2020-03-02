using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class ProductQAProjections
    {
        public static ProductQAVm ToVm(this ProductQA productQA) => new ProductQAVm
        {
            Id = productQA.Id,
            QuestionAndAnswer = productQA.QuestionAndAnswer
        };
        public static IQueryable<ProductQAVm> ToVm(this IQueryable<ProductQA> query) => query.Select(productQA => new ProductQAVm 
        {
            Id = productQA.Id,
            QuestionAndAnswer = productQA.QuestionAndAnswer
        });

        public static IEnumerable<ProductQAVm> ToVm(this IEnumerable<ProductQA> query) => query.Select(productQA => new ProductQAVm
        {
            Id = productQA.Id,
            QuestionAndAnswer = productQA.QuestionAndAnswer
        });
    }
}
