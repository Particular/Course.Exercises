namespace SecurityServiceAdapter
{
    using NServiceBus.Config;
    using NServiceBus.Config.ConfigurationSource;

    public class ConfigOverride : IProvideConfiguration<RijndaelEncryptionServiceConfig>
    {
        public RijndaelEncryptionServiceConfig GetConfiguration()
        {
            return new RijndaelEncryptionServiceConfig
            {
                //this key could be fetched from a REST/WS call
                Key = "gdDbqRpqdRbTs3mhdZh9qCaDaxJXl+e7"
            };
        }
    }
}

