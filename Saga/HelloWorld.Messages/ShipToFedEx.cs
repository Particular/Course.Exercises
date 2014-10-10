namespace HelloWorld.Messages
{
    using System;
    using NServiceBus;

    [TimeToBeReceived("0:0:15")]
    public class ShipToFedEx : ICommand
    {
        public Guid OrderId { get; set; }
        public string Order { get; set; }
    }
}