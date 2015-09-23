namespace WebApplication1
{
    using NServiceBus;
    using NServiceBus.MessageMutator;
    using NServiceBus.Unicast.Messages;

    public class AuthenticationMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(LogicalMessage logicalMessage, TransportMessage transportMessage)
        {
            //in a real life scenario you would probably get the user from
            // the HTTP pipeline
            transportMessage.Headers["user"] = "udi";
        }

        public void Customize(BusConfiguration configuration)
        {
            configuration.RegisterComponents(
                c => c.ConfigureComponent<AuthenticationMutator>
                    (DependencyLifecycle.InstancePerCall));
        }
    }
}