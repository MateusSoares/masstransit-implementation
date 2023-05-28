using MassTransit.WebApi.Messages;

namespace MassTransit.WebApi.Consumers
{
    public class CreateOrderConsumer : IConsumer<CreateOrder>
    {
        public Task Consume(ConsumeContext<CreateOrder> context)
        {
            Console.WriteLine($"Identificador do pedido: {context.Message.Id}");
            return Task.CompletedTask;
        }
    }
}
