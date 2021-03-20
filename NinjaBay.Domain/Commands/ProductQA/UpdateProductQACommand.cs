using System;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Commands.ProductQA
{
    public class UpdateProductQaCommand : IRequest<DefaultResult>
    {
        [JsonIgnore] public Guid Id { get; set; }

        public QuestionAnswer QuestionsAndAnswer { get; set; }
    }
}