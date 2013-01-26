using NServiceBus;

namespace HelloWorldQueryServer
{
    public class Class1 : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            NServiceBus.Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com")
                .RijndaelEncryptionService();
        }
    }
}
