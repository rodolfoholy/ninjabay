using SenacSp.ProjetoIntegrador.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.ViewModels
{
    public class ProductQAVm
    {
        public Guid Id { get;  set; }
        public QuestionAnswer QuestionAndAnswer { get;  set; }
    }
}
