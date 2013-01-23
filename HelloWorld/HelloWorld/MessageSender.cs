using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messages;
using NServiceBus;
using log4net;

namespace HelloWorld
{
    class MessageSender : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            var message = new Request { SaySomething = "Say something" };
            Bus.Send("helloWorldServer", message);
            LogManager.GetLogger("MessageSender").Info("Sent message.");
        }

        public void Stop()
        {

        }
    }
}
