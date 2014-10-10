namespace HelloWorld.Messages
{
    using System;
    using NServiceBus;

    public class ShipToUps : ICommand
    {
        public Guid OrderId { get; set; }
        public string Data { get; set; }
    }
}