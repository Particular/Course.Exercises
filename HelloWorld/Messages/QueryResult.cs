namespace Messages
{
    [Message]
    public class QueryResult
    {
        public QueryResult(string saySomething)
        {
            SaySomething = saySomething;
        }

        public string SaySomething { get; private set; }
    }
}