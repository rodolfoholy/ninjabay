using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Contracts.Services
{
    public interface IPasswordHasherService
    {
        string Hash(string password);

        bool Check(string hash,
            string password);
    }
}