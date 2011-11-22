using System;
using System.Collections.Generic;

namespace Infrastructure
{
    /// <summary>
    /// Derived aggregates need an empty ctor!
    /// </summary>
    public abstract class AggregateRoot
    {
        private readonly List<Event> _changes = new List<Event>();
       
        public abstract Guid Id { get; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history)
                ApplyChange(e);
        }

        protected void ApplyAndStoreChange(Event @event)
        {
            ApplyChange(@event);
            _changes.Add(@event);
        }

        private void ApplyChange(Event @event)
        {
            this.AsDynamic().Apply(@event);
        }
    }
}