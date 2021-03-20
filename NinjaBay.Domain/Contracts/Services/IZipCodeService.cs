using System.Threading.Tasks;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Contracts.Services
{
    public interface IZipCodeService
    {
        Task<Address> GetAdressByZipcode(string cep);
    }
}