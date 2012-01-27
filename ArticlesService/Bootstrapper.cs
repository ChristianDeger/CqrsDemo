using System;

using Articles.Commands;
using Articles.Domain;
using Articles.ReadModel;

using Infrastructure;

namespace ArticlesService
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            WireupInfrastructure();

            ServiceLocator.CommandSender.Send(new InsertArticle(Guid.NewGuid(), "Test"));
        }

        void WireupInfrastructure()
        {
            var bus = new FakeBus();
            var storage = new EventStore(bus);
            var repository = new Repository<Article>(storage);
            var discovery = new MessageHandlerDiscovery(bus);

            discovery.AddMessageReciever(new ArticleCommandHandler(repository));
            discovery.AddMessageReciever(new ArticleListEventHandler());
            discovery.AddMessageReciever(new ArticleDetailsEventHandler());
            discovery.AddMessageReciever(new ArticlePriceChangedEventHandler());

            ServiceLocator.RegisterBus(bus);
        }
    }
}