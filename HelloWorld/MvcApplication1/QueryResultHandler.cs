using System.Diagnostics;
using Messages;
using NServiceBus;

namespace MvcApplication1
{
    public class QueryResultHandler : IHandleMessages<QueryResult>
    {
        public void Handle(QueryResult message)
        {
            Debug.WriteLine(message.SaySomething);
        }
    }
}