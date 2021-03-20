using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Commands.ProductQA
{
    public class AddQuestionsAndAnswerProductCommand : IRequest<DefaultResult>
    {
        [JsonIgnore] public Guid Id { get; set; }

        public IEnumerable<QuestionAnswer> QuestionsAndAnswers { get; set; } = new List<QuestionAnswer>();
    }
}