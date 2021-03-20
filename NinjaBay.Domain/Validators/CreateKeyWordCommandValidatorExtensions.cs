using System;
using FluentValidation;
using NinjaBay.Domain.Commands.KeyWord;

namespace NinjaBay.Domain.Validators
{
    public static class CreateKeyWordCommandValidatorExtensions
    {
        public static void RegisterRules<T>(this AbstractValidator<T> validator) where T : CreateKeyWordCommand
        {
            validator.RuleFor(x => x.Word)
                .NotEmpty()
                .WithMessage("Campo palavra está vazio");
        }
    }

    public class CreateKeyWordCommandValidator : AbstractValidator<CreateKeyWordCommand>
    {
        public CreateKeyWordCommandValidator()
        {
            this.RegisterRules();
        }
    }

    public class UpdateKeyWordCommandValidator : AbstractValidator<UpdateKeyWordCommand>
    {
        public UpdateKeyWordCommandValidator()
        {
            this.RegisterRules();
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty)
                .WithMessage("Id da palavra chave está vazio ou nulo");
        }
    }
}