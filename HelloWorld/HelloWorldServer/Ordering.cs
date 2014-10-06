namespace HelloWorldServer
{
    using NServiceBus;

    internal class Ordering : ISpecifyMessageHandlerOrdering
    {
        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }
    }
}