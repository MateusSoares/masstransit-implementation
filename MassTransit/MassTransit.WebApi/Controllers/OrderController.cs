using MassTransit.WebApi.Messages;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IBus _bus;

        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost("CreateOrder", Name = "CreateOrder")]
        public async void Post()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:CreateOrder"));

            await endpoint.Send(new CreateOrder { Id = Guid.NewGuid() });
        }

        [HttpPost("ConfirmOrder", Name = "ConfirmOrder")]
        public async void Post([FromBody] Guid orderId)
        {
            await _bus.Publish(new ConfirmOrder { Id = orderId, Number = 8 });
        }
    }
}