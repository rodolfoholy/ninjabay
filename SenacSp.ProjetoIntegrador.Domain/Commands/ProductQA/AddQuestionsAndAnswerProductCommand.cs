using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Products
{
    public class AddQuestionsAndAnswerProductCommand :  IRequest<DefaultResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public IEnumerable<QuestionAnswer> QuestionsAndAnswers { get; set; } = new List<QuestionAnswer>();
    }
}
