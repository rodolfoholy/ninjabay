using FluentValidation;
using SenacSp.ProjetoIntegrador.Domain.Commands.User;
using SenacSp.ProjetoIntegrador.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Validators
{
    public static class UserCommandValidatorExtensions
    {
        public static void RegisterRules<T>(this AbstractValidator<T> validator) where T : CreateUserCommand
        {
            validator.RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O campo E-Mail está vazio ")
                .When(x => !x.Email.IsNull());

            validator.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O campo Nome está vazio")
                .When(x => !x.Name.IsNull());

            validator.RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("O campo Senha está vazio")
                .When(x => !x.Password.IsNull());
        
            validator.RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("O E-Mail Deve ser valido")
                .When(x => !x.Email.IsNull());
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RegisterRules();
        }
    }

}
