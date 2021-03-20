using System.ComponentModel;

namespace NinjaBay.Shared.Enums
{
    public enum EPaymentStatus
    {
        [Description("Aguardando Aprovação")] WaitingApproval,
        [Description("Aprovado")] Approved,
        [Description("Desaprovado")] Unapproved,
        [Description("Aguardando retirada")] WaitingwWithdrawal,
        [Description("Em transito")] InTransit,
        [Description("Entregue")] Delivered
    }
}