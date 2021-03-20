using System;
using FluentValidation;
using NinjaBay.Domain.Commands.ProductQA;

namespace NinjaBay.Domain.Validators.ProductQA
{
    public class DeleteProductQaCommandValidator : AbstractValidator<DeleteProductQaCommand>
    {
        public DeleteProductQaCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id da pergunta e resposta está nulo");
        }
    }
}