namespace HelloWorld.Messages.Commands
{
    using System;
    
    public class ShippOrder
    {
        public Guid OrderId { get; set; }
        
        public string ProductName { get; set; }
        
        public string ShippingAddress { get; set; }
        
        public string Order { get; set; }
    }
}
