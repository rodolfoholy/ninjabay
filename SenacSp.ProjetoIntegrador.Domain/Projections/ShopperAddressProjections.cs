using System.Collections.Generic;
using System.Linq;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;

namespace SenacSp.ProjetoIntegrador.Domain.Projections
{
    public static class ShopperAddressProjections
    {
        public static ShopperAddressVm ToVm(this ShopperAddress address) => new ShopperAddressVm
        {
            Id = address.Id,
            Address = address.Address,
            Name = address.Name,
            Type = address.Type
        };

        public static IQueryable<ShopperAddressVm> ToVm(this IQueryable<ShopperAddress> query) =>
            query.Select(address => new ShopperAddressVm
            {
                Id = address.Id,
                Address = address.Address,
                Name = address.Name,
                Type = address.Type
            });
        
        public static IEnumerable<ShopperAddressVm> ToVm(this IEnumerable<ShopperAddress> query) =>
            query.Select(address => new ShopperAddressVm
            {
                Id = address.Id,
                Address = address.Address,
                Name = address.Name,
                Type = address.Type
            });
        
        
    }
}