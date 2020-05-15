using System.ComponentModel;

namespace SenacSp.ProjetoIntegrador.Shared.Enums
{
    public enum EPaymentStatus
    {
       
        [Description("Aguardando Aprovação")] WaitingApproval,
        [Description("Aprovado")]Approved,
        [Description("Desaprovado")]Unapproved
    }
}