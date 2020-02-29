using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.KeyWords
{
   public class CreateKeyWordCommand : IRequest<DefaultResult>
    {
        public string Word { get; set; }
    }
}
