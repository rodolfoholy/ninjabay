using System;
using FluentValidation;
using NinjaBay.Domain.Commands.Products;

namespace NinjaBay.Domain.Validators
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