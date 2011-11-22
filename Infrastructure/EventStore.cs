using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);

        IEnumerable<Event> GetEventsForAggregate(Guid aggregateId);
    }

    public class EventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;

        private struct EventDescriptor
        {
            public readonly Event EventData;
            public readonly int Version;

            public EventDescriptor(Event eventData, int version)
            {
                EventData = eventData;
                Version = version;
            }
        }

        public EventStore(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>(); 
        
        public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
        {
            var eventDescriptors = GetEventDescriptorsForAggregate(aggregateId, expectedVersion);
            var i = expectedVersion;
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;
                eventDescriptors.Add(new EventDescriptor(@event, i));
                _publisher.Publish(@event);
            }
        }

        public IEnumerable<Event> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }

            return eventDescriptors.Select(x => x.EventData).ToList();
        }

        List<EventDescriptor> GetEventDescriptorsForAggregate(Guid aggregateId, int expectedVersion)
        {
            List<EventDescriptor> eventDescriptors;
            if (_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                GuardExpectedVersion(expectedVersion, eventDescriptors);
            }
            else
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }

            return eventDescriptors;
        }

        static void GuardExpectedVersion(int expectedVersion, List<EventDescriptor> eventDescriptors)
        {
            if (eventDescriptors.Last().Version != expectedVersion && expectedVersion != -1)
            {
                throw new ConcurrencyException();
            }
        }
    }

    public class AggregateNotFoundException : Exception
    {
    }

    public class ConcurrencyException : Exception
    {
    }
}