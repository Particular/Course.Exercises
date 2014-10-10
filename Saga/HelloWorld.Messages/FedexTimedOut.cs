namespace HelloWorld.Messages
{
    using System;

    public class FedexTimedOut
    {
        public Guid OrderId { get; set; }
    }
}