using System;
using System.Linq;
using FluentValidation;
using NinjaBay.Domain.Commands.ProductQA;

namespace NinjaBay.Domain.Validators.ProductQA
{
    public class AddQuestionsAndAnswerProductCommandValidator : AbstractValidator<AddQuestionsAndAnswerProductCommand>
    {
        public AddQuestionsAndAnswerProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id do produto está nulo");

            RuleFor(x
                    => x.QuestionsAndAnswers.Select(y => y.Question))
                .NotEmpty()
                .WithMessage("Existem Perguntas nulas vazias")
                .When(x => x.QuestionsAndAnswers != null);

            RuleFor(x
                    => x.QuestionsAndAnswers.Select(y => y.Answer))
                .NotEmpty()
                .WithMessage("Existem Respostas nulas ou vazias")
                .When(x => x.QuestionsAndAnswers != null);
        }
    }
}