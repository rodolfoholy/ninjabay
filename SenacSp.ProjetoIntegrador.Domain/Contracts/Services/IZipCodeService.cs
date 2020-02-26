using SenacSp.ProjetoIntegrador.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Domain.Contracts.Services
{
    public interface IZipCodeService
    {
        Task<Address> GetAdressByZipcode(string cep);
    }
}