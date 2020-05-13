using System;

namespace SenacSp.ProjetoIntegrador.Domain.CommandViewModels
{
    public class PaymentCardViewModel
    {
        public string Number { get; set; }

        public string Cvv { get;  set; }

        public DateTime ExpirationDate { get; set; }
    }
}