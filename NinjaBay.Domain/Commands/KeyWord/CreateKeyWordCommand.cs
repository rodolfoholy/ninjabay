using MediatR;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.KeyWord
{
    public class CreateKeyWordCommand : IRequest<DefaultResult>
    {
        public string Word { get; set; }
    }
}