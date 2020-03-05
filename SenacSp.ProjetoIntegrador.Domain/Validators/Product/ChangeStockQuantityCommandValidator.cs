using System;
using FluentValidation;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;

namespace SenacSp.ProjetoIntegrador.Domain.Validators.Product
{
    public class ChangeStockQuantityCommandValidator : AbstractValidator<ChangeStockQuantityCommand>
    {
        public ChangeStockQuantityCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id do produto está nulo");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("A quantidade do produto está vazia");
        }
    }
}