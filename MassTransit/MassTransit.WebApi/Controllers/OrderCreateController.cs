using MassTransit.WebApi.Messages;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderCreateController : ControllerBase
    {
        private readonly ILogger<OrderCreateController> _logger;
        private readonly IBus _bus;

        public OrderCreateController(ILogger<OrderCreateController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet(Name = "CreateOrder")]
        public async void Get()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:OrderCreate"));

            await endpoint.Send(new Order { Id = Guid.NewGuid() });
        }
    }
}