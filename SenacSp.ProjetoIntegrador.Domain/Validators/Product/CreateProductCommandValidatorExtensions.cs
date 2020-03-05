using System;
using FluentValidation;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;
using SenacSp.ProjetoIntegrador.Shared.Extensions;

namespace SenacSp.ProjetoIntegrador.Domain.Validators.Product
{
    public static class CreateProductCommandValidatorExtensions
    {
        public static void RegisterRules<T>(this AbstractValidator<T> validator) where T : CreateProductCommand
        {
            validator.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O campo Nome está vazio ")
                .When(x => !x.Name.IsNull());
            
            validator.RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("O campo Descrição está vazio")
                .When(x => !x.Description.IsNull());
        }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            this.RegisterRules();
        }
    }

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            this.RegisterRules();
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id do produto está nulo");
        }
    }
}