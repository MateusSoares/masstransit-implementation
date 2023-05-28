using MassTransit.WebApi.Messages;

namespace MassTransit.WebApi.Consumers
{
    public class UpdateOrderItemsConsumer : IConsumer<ConfirmOrder>
    {
        public Task Consume(ConsumeContext<ConfirmOrder> context)
        {
            Console.WriteLine($"Items do pedido foram confirmados: {context.Message.Id}");
            return Task.CompletedTask;
        }
    }
}
