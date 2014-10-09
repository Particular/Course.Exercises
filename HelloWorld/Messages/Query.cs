namespace Messages
{
    [Message]
    public class Query
    {
        public Query(int numberOfResponses)
        {
            NumberOfResponses = numberOfResponses;
        }

        public int NumberOfResponses { get; private set; }
    }
}