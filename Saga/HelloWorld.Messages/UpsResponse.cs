namespace HelloWorld.Messages
{
    using System;
    using NServiceBus;

    public class UpsResponse : IMessage
    {
        public Guid OrderId { get; set; }
    }
}