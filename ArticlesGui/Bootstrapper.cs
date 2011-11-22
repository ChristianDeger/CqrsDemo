using Infrastructure;

namespace ArticlesGui
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            WireupInfrastructure();
        }

        void WireupInfrastructure()
        {
            //var bus = new FakeBus();
            //var storage = new EventStore(bus);
            //var repository = new Repository<Article>(storage);
            //var discovery = new MessageHandlerDiscovery(bus);

            //discovery.AddMessageReciever(new ArticleCommandHandler(repository));
            //discovery.AddMessageReciever(new ArticleListEventHandler());

            //ServiceLocator.RegisterBus(bus);
        }
    }
}