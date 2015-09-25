namespace HelloWorld.Messages.Commands
{
    using System;
    
    public class ShipToUps
    {
        public Guid OrderId { get; set; }

        public string Data { get; set; }
    }
}