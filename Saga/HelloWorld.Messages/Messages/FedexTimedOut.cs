namespace HelloWorld.Messages.Messages
{
    using System;

    public class FedexTimedOut
    {
        public Guid OrderId { get; set; }
    }
}