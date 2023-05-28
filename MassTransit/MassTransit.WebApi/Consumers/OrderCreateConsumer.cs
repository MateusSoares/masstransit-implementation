using MassTransit.WebApi.Messages;

namespace MassTransit.WebApi.Consumers
{
    public class OrderCreateConsumer : IConsumer<Order>
    {
        public Task Consume(ConsumeContext<Order> context)
        {
            Console.WriteLine($"Identificador do pedido: {context.Message.Id}");
            return Task.CompletedTask;
        }
    }
}
