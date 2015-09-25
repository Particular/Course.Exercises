namespace HelloWorld.ShipToUps
{
    using System;
    using Messages;
    using Messages.Commands;
    using Messages.Messages;
    using NServiceBus;

    public class ShipToUpsHandler : IHandleMessages<ShipToUps>
    {
        public IBus Bus { get; set; }

        public void Handle(ShipToUps message)
        {
            Console.WriteLine("Handling ShipToUps with id: {0}", message.OrderId);

            Bus.Reply<UpsResponse>(m => { m.OrderId = message.OrderId; });
        }
    }
}
