#nullable enable
using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.CommandViewModels;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Order
{
    public class FinalizeOrderCommand : IRequest<CompleteOrderResult>
    {
        public List<ProductCommandViewModel> Itens { get; set; }
        
        public Guid ShippingAddressId { get; set; }

        public EPaymentMethod PaymentMethod { get;  set; }

        public PaymentCardViewModel? CreditCard { get; set; }
        
        [JsonIgnore]
        public SessionUser SessionUser { get; set; }
        
    }
}