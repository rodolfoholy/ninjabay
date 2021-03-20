using System;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.ViewModels
{
    public class ProductQAVm
    {
        public Guid Id { get; set; }
        public QuestionAnswer QuestionAndAnswer { get; set; }
    }
}