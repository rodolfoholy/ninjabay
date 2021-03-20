using System.ComponentModel;

namespace NinjaBay.Shared.Enums
{
    public enum EUserType
    {
        [Description("Administrador")] Administrator,
        [Description("Cliente")] Shopper,
        [Description("Estoquista")] Stocker
    }
}