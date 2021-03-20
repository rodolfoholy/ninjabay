using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class ProductProjections
    {
        public static ProductVm ToVm(this Product product)
        {
            return new ProductVm
            {
                Id = product.Id,
                Description = product.Description,
                IsAvailable = product.IsAvailabe(product),
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                KeyWords = product.KeyWords.Select(x => x.KeyWord).ToVm(),
                QuestionAndAnswers = product.QuestionsAndAnswers.ToVm(),
                Links = product.Images.ToVm()
            };
        }

        public static IQueryable<ProductVm> ToVm(this IQueryable<Product> query)
        {
            return query.Select(product => new ProductVm
            {
                Id = product.Id,
                Description = product.Description,
                IsAvailable = product.IsAvailabe(product),
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                KeyWords = product.KeyWords.Select(x => x.KeyWord).ToVm(),
                QuestionAndAnswers = product.QuestionsAndAnswers.ToVm(),
                Links = product.Images.ToVm()
            });
        }

        public static IEnumerable<ProductVm> ToVm(this IEnumerable<Product> query)
        {
            return query.Select(product => new ProductVm
            {
                Id = product.Id,
                Description = product.Description,
                IsAvailable = product.IsAvailabe(product),
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                KeyWords = product.KeyWords.Select(x => x.KeyWord).ToVm(),
                QuestionAndAnswers = product.QuestionsAndAnswers.ToVm(),
                Links = product.Images.ToVm()
            });
        }
    }
}