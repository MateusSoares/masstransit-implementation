using MassTransit.WebApi.Messages;

namespace MassTransit.WebApi.Consumers
{
    public class CreateOrderBillingConsumer : IConsumer<ConfirmOrder>
    {
        public Task Consume(ConsumeContext<ConfirmOrder> context)
        {
            Console.WriteLine($"Cobrança para pedido confirmada: {context.Message.Id}");
            return Task.CompletedTask;
        }
    }
}
