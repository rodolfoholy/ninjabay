using System.Collections.Generic;
using System.Linq;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.ViewModels;

namespace NinjaBay.Domain.Projections
{
    public static class ShopperAddressProjections
    {
        public static ShopperAddressVm ToVm(this ShopperAddress address)
        {
            return new ShopperAddressVm
            {
                Id = address.Id,
                Address = address.Address,
                Name = address.Name,
                Type = address.Type
            };
        }

        public static IQueryable<ShopperAddressVm> ToVm(this IQueryable<ShopperAddress> query)
        {
            return query.Select(address => new ShopperAddressVm
            {
                Id = address.Id,
                Address = address.Address,
                Name = address.Name,
                Type = address.Type
            });
        }

        public static IEnumerable<ShopperAddressVm> ToVm(this IEnumerable<ShopperAddress> query)
        {
            return query.Select(address => new ShopperAddressVm
            {
                Id = address.Id,
                Address = address.Address,
                Name = address.Name,
                Type = address.Type
            });
        }
    }
}