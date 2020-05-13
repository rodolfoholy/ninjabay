using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Security;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.ShopperAddress
{
    public class CreateShopperAddressCommand : IRequest<DefaultResult>
    {
        public string Name { get; set; }
        
        public EAddressType Type { get; set; }
        
        public Address Address { get; set; }
        
        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}