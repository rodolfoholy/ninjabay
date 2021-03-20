using System;
using FluentValidation;
using NinjaBay.Domain.Commands.ProductImage;

namespace NinjaBay.Domain.Validators.ProductImage
{
    public class InsertProductImageCommandValidator : AbstractValidator<InsertProductImageCommand>
    {
        public InsertProductImageCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id do produto está vazio ou nulo");

            RuleFor(x => x.Images)
                .NotEmpty()
                .WithMessage("Imagem é nula");
        }
    }
}