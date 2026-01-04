namespace MassTransit.WebApi.Messages
{
    public class CreateOrder
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
