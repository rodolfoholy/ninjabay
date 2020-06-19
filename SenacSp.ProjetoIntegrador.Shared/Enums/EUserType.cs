using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.Enums
{
    public enum EUserType
    {
        [Description("Administrador")]Administrator,
        [Description("Cliente")]Shopper,
        [Description("Estoquista")]Stocker
    }
}

