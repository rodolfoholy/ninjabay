using System;
using FluentValidation;
using NinjaBay.Domain.Commands.ProductQA;

namespace NinjaBay.Domain.Validators.ProductQA
{
    public class UpdateProductQaCommandValidator : AbstractValidator<UpdateProductQaCommand>
    {
        public UpdateProductQaCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id da pergunta e resposta está nulo");

            RuleFor(x => x.QuestionsAndAnswer.Answer)
                .NotEmpty()
                .WithMessage("Campo Resposta deve ser preenchido ")
                .When(x => x.QuestionsAndAnswer != null);

            RuleFor(x => x.QuestionsAndAnswer.Question)
                .NotEmpty()
                .WithMessage("Campo Pergunta deve ser preenchido ")
                .When(x => x.QuestionsAndAnswer != null);


            RuleFor(x => x.QuestionsAndAnswer)
                .NotEmpty()
                .WithMessage("Pergunta e resposta deve ser preenchido");
        }
    }
}