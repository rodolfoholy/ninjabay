using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class KeyWordProjections
    {
        public static KeyWordVm ToVm(this KeyWord keyWord) => new KeyWordVm
        {
            Id = keyWord.Id,
            Word = keyWord.Word
        };
        public static IQueryable<KeyWordVm> ToVm(this IQueryable<KeyWord> query) => query.Select(keyWord => new KeyWordVm 
        {
            Id = keyWord.Id,
            Word = keyWord.Word
        });

        public static IEnumerable<KeyWordVm> ToVm(this IEnumerable<KeyWord> query) => query.Select(keyWord => new KeyWordVm
        {
            Id = keyWord.Id,
            Word = keyWord.Word
        });
    }
}
