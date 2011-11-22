using System.Linq;
using Infrastructure;
using Machine.Specifications;

namespace Articles
{
    public static class AggregateRootTestHelper
    {
        public static void ShouldEmitOneEventOfType<TEvent>(this AggregateRoot aggregate)
        {
            aggregate.GetUncommittedChanges().Count().ShouldEqual(1);
            aggregate.GetUncommittedChanges().First().ShouldBeOfType<TEvent>();
        }

        public static TEvent EmittedEvent<TEvent>(this AggregateRoot aggregate) where TEvent : Event
        {
            return (TEvent)aggregate.GetUncommittedChanges().First(x => x.GetType() == typeof (TEvent));
        }
    }
}