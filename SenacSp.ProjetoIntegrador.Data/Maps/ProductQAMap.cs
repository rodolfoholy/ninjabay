using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Maps
{
    internal class ProductQAMap : IEntityTypeConfiguration<ProductQA>
    {
        public void Configure(EntityTypeBuilder<ProductQA> builder)
        {
            builder.ToTable("product_question_answers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.MapQuestionAnswer(x => x.QuestionAndAnswer);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.QuestionsAndAnswers)
                .HasForeignKey(x => x.ProductId);
        }
    }
    
}
