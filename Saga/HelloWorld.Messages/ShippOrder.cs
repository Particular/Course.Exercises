namespace HelloWorld.Messages
{
    using System;
    using NServiceBus;

    public class ShippOrder : ICommand
    {
        public Guid OrderId { get; set; }

        public string ProductName { get; set; }

        public string ShippingAddress { get; set; }
        public string Order { get; set; }
    }
}
