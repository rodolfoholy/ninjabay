using System;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Shopper
{
    public class UpdateShopperCommand : BaseCommandWithSessionUser ,IRequest<SaveShopperResult>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}