using System;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Order
{
    public class ChangeOrderStatusCommand : IRequest<DefaultResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        
        public EPaymentStatus Status { get; set; }
        
        [JsonIgnore]
        public SessionUser SessionUser { get; set; }
    }
}