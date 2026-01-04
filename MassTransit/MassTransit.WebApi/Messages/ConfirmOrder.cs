namespace MassTransit.WebApi.Messages
{
    public class ConfirmOrder
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}