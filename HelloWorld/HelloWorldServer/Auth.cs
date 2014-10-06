namespace HelloWorldServer
{
    using NServiceBus;
    using NServiceBus.Logging;

    internal class Auth : IHandleMessages<object>
    {
        public IBus Bus { get; set; }

        public void Handle(object message)
        {
            if (!Authorized(Bus.GetMessageHeader(message, "user")))
            {
                LogManager.GetLogger("Auth").Warn("User not authorized.");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
            }
            else
                LogManager.GetLogger("Auth").Info("User authorized.");
        }

        private bool Authorized(string user)
        {
            return user == "udi";
        }
    }
}