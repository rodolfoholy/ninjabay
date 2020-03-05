using System;
using FluentValidation;
using SenacSp.ProjetoIntegrador.Domain.Commands.ProductImage;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;

namespace SenacSp.ProjetoIntegrador.Domain.Validators.ProductImage
{
    public class InsertProductImageCommandValidator : AbstractValidator<InsertProductImageCommand>
    {
        public InsertProductImageCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id do produto está vazio ou nulo");

            RuleFor(x => x.Files)
                .NotEmpty()
                .WithMessage("Imagem é nula");
        }
    }
}