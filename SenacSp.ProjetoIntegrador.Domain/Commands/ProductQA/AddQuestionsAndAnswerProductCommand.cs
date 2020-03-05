using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.ProductQA
{
    public class AddQuestionsAndAnswerProductCommand :  IRequest<DefaultResult>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public IEnumerable<QuestionAnswer> QuestionsAndAnswers { get; set; } = new List<QuestionAnswer>();
    }
}
