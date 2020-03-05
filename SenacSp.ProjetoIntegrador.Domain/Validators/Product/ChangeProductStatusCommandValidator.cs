using System;
using FluentValidation;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;

namespace SenacSp.ProjetoIntegrador.Domain.Validators
{
    public class ChangeProductStatusCommandValidator : AbstractValidator<ChangeProductStatusCommand>
    {
        public ChangeProductStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id do produto está nulo");
        }
    }
}