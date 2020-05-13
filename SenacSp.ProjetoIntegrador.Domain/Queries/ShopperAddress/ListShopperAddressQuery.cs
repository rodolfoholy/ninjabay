using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.Queries.ShopperAddress
{
    public class ListShopperAddressQuery : IRequest<IEnumerable<ShopperAddressVm>>
    {
        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}