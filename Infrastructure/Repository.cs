using System;

namespace Infrastructure
{
    public interface IRepository<out TAggregate> where TAggregate : AggregateRoot, new()
    {
        /// <summary>
        /// Save newly created aggregates with expectedVersion = -1
        /// </summary>
        void Save(AggregateRoot aggregate, int expectedVersion);
        TAggregate GetById(Guid id);
    }

    public class Repository<TAggregate> : IRepository<TAggregate> where TAggregate: AggregateRoot, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Save newly created aggregates with expectedVersion = -1
        /// </summary>
        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
            aggregate.MarkChangesAsCommitted();
        }

        public TAggregate GetById(Guid id)
        {
            var events = _storage.GetEventsForAggregate(id);
            return events.RestoreAggregate<TAggregate>();
        }
    }
}
