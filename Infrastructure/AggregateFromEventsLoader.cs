using System.Collections.Generic;

namespace Infrastructure
{
    public static class AggregateFromEventsLoader
    {
        public static TAggregate RestoreAggregate<TAggregate>(this IEnumerable<Event> history)
            where TAggregate : AggregateRoot, new()
        {
            var aggregate = new TAggregate();
            aggregate.LoadsFromHistory(history);
            return aggregate;
        }
    }

}