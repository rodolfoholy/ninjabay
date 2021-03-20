using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class KeyWordProjections
    {
        public static KeyWordVm ToVm(this KeyWord keyWord)
        {
            return new KeyWordVm
            {
                Id = keyWord.Id,
                Word = keyWord.Word
            };
        }

        public static IQueryable<KeyWordVm> ToVm(this IQueryable<KeyWord> query)
        {
            return query.Select(keyWord => new KeyWordVm
            {
                Id = keyWord.Id,
                Word = keyWord.Word
            });
        }

        public static IEnumerable<KeyWordVm> ToVm(this IEnumerable<KeyWord> query)
        {
            return query.Select(keyWord => new KeyWordVm
            {
                Id = keyWord.Id,
                Word = keyWord.Word
            });
        }
    }
}