using NServiceBus;
using NServiceBus.Config;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast.Transport;

namespace MvcApplication1
{
    public class AuthenticationMutator : IMutateOutgoingTransportMessages,
                                         INeedInitialization
    {
        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            //in a real life scenario you would probably get the user from
            // HttpContext.Current.Request.Params[“user”] or similar 
            transportMessage.Headers["user"] = "udi";
        }

        public void Init()
        {
            Configure.Instance.Configurer
                .ConfigureComponent<AuthenticationMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}
