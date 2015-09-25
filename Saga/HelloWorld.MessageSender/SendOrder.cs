namespace HelloWorld.MessageSender
{
    using System;
    using Messages.Commands;
    using NServiceBus;

    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                var id = Guid.NewGuid();

                Bus.Send(new ShippOrder() {ProductName = "New shoes", OrderId = id, ShippingAddress = "Adress...."});

                Console.WriteLine("==========================================================================");
                Console.WriteLine("Send a new ShippOrder message with id: {0}", id.ToString("N"));
            }
        }

        public void Stop()
        {
        }
    }
}