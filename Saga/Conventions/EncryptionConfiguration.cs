using NServiceBus;

namespace Conventions
{
    public class EncryptionConfiguration : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.RijndaelEncryptionService();
        }
    }
}