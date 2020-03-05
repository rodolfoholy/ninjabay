using System;
using FluentValidation;
using SenacSp.ProjetoIntegrador.Domain.Commands.ProductImage;

namespace SenacSp.ProjetoIntegrador.Domain.Validators.ProductImage
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