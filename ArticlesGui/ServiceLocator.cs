using Infrastructure;

namespace ArticlesGui
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
    }
}