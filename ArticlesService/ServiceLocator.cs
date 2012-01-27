using Articles.ReadModel;

using Infrastructure;

namespace ArticlesService
{
    public static class ServiceLocator
    {
        static FakeBus _bus;

        public static void RegisterBus(FakeBus bus)
        {
            _bus = bus;
        }

        public static ICommandSender CommandSender
        {
            get { return _bus; }
        }

        public static IArticleReadModelFacade ArticlesReadModel
        {
            get { return new ArticleReadModelFacade(); }
        }
    }
}