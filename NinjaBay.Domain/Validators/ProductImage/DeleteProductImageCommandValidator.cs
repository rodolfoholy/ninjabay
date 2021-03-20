using System;
using FluentValidation;
using NinjaBay.Domain.Commands.ProductImage;

namespace NinjaBay.Domain.Validators.ProductImage
{
    public class DeleteProductImageCommandValidator : AbstractValidator<DeleteProductImageCommand>
    {
        public DeleteProductImageCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id da imagem do produto está nulo ou vazio");
        }
    }
}