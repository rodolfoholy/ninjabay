using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Products;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class ProductQACommandHandler : BaseCommandHandler
    {
        private readonly IProductRepository _productRepository;

     
        public ProductQACommandHandler(IUnitOfWork uow, IDomainNotification notifications) : base(uow, notifications)
        {
        }
    }
}
