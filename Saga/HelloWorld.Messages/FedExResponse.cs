namespace HelloWorld.Messages
{
    using System;
    using NServiceBus;

    public class FedExResponse : IMessage
    {
        public Guid OrderId { get; set; }
    }
}