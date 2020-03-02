using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class ProductProjections
    {
        public static ProductVm ToVm(this Product product) => new ProductVm 
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

        public static IQueryable<ProductVm> ToVm(this IQueryable<Product> query) => query.Select(product => new ProductVm 
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

        public static IEnumerable<ProductVm> ToVm(this IEnumerable<Product> query) => query.Select(product => new ProductVm
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
