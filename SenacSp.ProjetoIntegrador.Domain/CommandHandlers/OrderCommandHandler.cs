using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Order;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class OrderCommandHandler : BaseCommandHandler,
        IRequestHandler<FinalizeOrderCommand, CompleteOrderResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IProductRepository productRepository, IOrderRepository orderRepository) : base(uow, notifications)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<CompleteOrderResult> Handle(FinalizeOrderCommand command, CancellationToken cancellationToken)
        {
            var result = new CompleteOrderResult();

            var success = true;
            
            var newOrder = Order.New(command.PaymentMethod, command.SessionUser.Id, command.ShippingAddressId);

            foreach (var item in command.Itens)
            {
                var product = await _productRepository.FindAsync(x => x.Id == item.ProductId);
               

                if (product.Quantity == 0)
                {
                    command.Itens.RemoveAll(x => x.ProductId == item.ProductId);
                    success = false;
                }else if (product.Quantity < item.Qt)
                {
                    command.Itens.FindAll(x => x.ProductId == item.ProductId).First().Qt = product.Quantity;
                    success = false;
                }

                newOrder.Products.Add(ProductOrder.New(item.ProductId, item.Qt, product.Price));
                newOrder.SetTotal(newOrder.Total + product.Price * item.Qt);
            }

            if (!success)
            {
                result.Message = "Infelizmente alguns dos itens selecionados não estão disponíveis no momento";
                result.Itens = command.Itens;
                return result;
            }
            
            await _orderRepository.AddAsync(newOrder);

            if (!await CommitAsync())
            {
                return null;
            }

            return result;
        }
    }
}