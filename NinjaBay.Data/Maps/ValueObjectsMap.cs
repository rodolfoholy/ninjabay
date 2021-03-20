using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Data.Maps
{
    internal static class Utils
    {
        public static EntityTypeBuilder<T> MapQuestionAnswer<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, QuestionAnswer>> exp) where T : class
        {
            return builder.OwnsOne(exp, b =>
            {
                b.Property(x => x.Question)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("question");

                b.Property(x => x.Answer)
                    .HasColumnType("varchar(525)")
                    .HasColumnName("answer");
            });
        }
    }
}