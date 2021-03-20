using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.Order;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class OrderCommandHandler : BaseCommandHandler,
        IRequestHandler<FinalizeOrderCommand, CompleteOrderResult>,
        IRequestHandler<ChangeOrderStatusCommand, DefaultResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IProductRepository productRepository, IOrderRepository orderRepository) : base(uow, notifications)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<DefaultResult> Handle(ChangeOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();
            var order = await _orderRepository.FindAsync(x => x.Id == command.Id);

            if (order == null) return result;

            order.ChangeOrderStatus(command.Status);
            _orderRepository.Modify(order);

            if (!await CommitAsync()) return null;

            return result;
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
                }
                else if (product.Quantity < item.Qt)
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

            if (!await CommitAsync()) return null;

            return result;
        }
    }
}