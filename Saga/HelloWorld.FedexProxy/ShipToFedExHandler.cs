namespace HelloWorld.FedexProxy
{
    using System;
    using Messages;
    using NServiceBus;

    public class ShipToFedExHandler : IHandleMessages<ShipToFedEx>
    {
        public IBus Bus { get; set; }

        public void Handle(ShipToFedEx message)
        {

            Console.WriteLine("Handling ShipToFedex with id: {0}", message.OrderId);

            Bus.Reply<FedExResponse>(m => { m.OrderId = message.OrderId; });
        }
    }
}
