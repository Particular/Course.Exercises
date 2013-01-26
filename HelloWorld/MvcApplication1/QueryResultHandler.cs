using Messages;
using NServiceBus;

namespace MvcApplication1
{
    public class QueryResultHandler : IHandleMessages<QueryResult>
    {
        public void Handle(QueryResult message)
        {
            message.Something.ToString();
        }
    }
}