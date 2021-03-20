using System.ComponentModel;

namespace NinjaBay.Shared.Enums
{
    public enum EPaymentMethod
    {
        [Description("Boleto")] Billet,
        [Description("Cartão de Credito")] CreditCard
    }
}