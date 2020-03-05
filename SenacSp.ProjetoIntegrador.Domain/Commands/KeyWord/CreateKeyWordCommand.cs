using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Results;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.KeyWord
{
   public class CreateKeyWordCommand : IRequest<DefaultResult>
    {
        public string Word { get; set; }
    }
}
