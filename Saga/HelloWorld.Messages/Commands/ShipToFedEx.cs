namespace HelloWorld.Messages.Commands
{
    using System;
    
    [Expires(15)]
    public class ShipToFedEx
    {
        public Guid OrderId { get; set; }

        public string Order { get; set; }
    }
}