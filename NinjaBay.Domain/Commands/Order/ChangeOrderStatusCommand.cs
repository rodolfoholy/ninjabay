using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Commands.Order
{
    public class ChangeOrderStatusCommand : IRequest<DefaultResult>
    {
        [JsonIgnore] public Guid Id { get; set; }

        public EPaymentStatus Status { get; set; }

        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}