#nullable enable
using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.CommandViewModels;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Commands.Order
{
    public class FinalizeOrderCommand : IRequest<CompleteOrderResult>
    {
        public List<ProductCommandViewModel> Itens { get; set; }

        public Guid ShippingAddressId { get; set; }

        public EPaymentMethod PaymentMethod { get; set; }

        public PaymentCardViewModel? CreditCard { get; set; }

        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}