namespace Conventions
{
    using System;
    using System.Linq;
    using NServiceBus;

    public class ConventionsConfiguration : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.EndsWith("Messages"))
                .DefiningTimeToBeReceivedAs(GetExpiration);
        }

        private TimeSpan GetExpiration(Type type)
        {
            dynamic expiresAttribute = type.GetCustomAttributes(true)
                        .SingleOrDefault(t => t.GetType()
                        .Name == "ExpiresAttribute");

            return expiresAttribute == null
                       ? TimeSpan.MaxValue
                       : expiresAttribute.ExpiresAfter;
        }
    }
}
