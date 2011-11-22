using System;
using System.Collections.Generic;
using System.Threading;

namespace Infrastructure
{
    public class FakeBus : ICommandSender, IEventPublisher, IHandlerRegistry
    {
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        public void RegisterHandler(Type messageType, Action<IMessage> handler)
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(messageType, out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(messageType, handlers);
            }

            handlers.Add(handler);
        }

        public void Send<T>(T command) where T : Command
        {
            List<Action<IMessage>> handlers; 
            if (_routes.TryGetValue(typeof(T), out handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("cannot send to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("no handler registered");
            }
        }

        public void Publish<T>(T @event) where T : Event
        {
            List<Action<IMessage>> handlers; 
            if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;
            foreach(var handler in handlers)
            {
                //dispatch on thread pool for added awesomeness
                var handler1 = handler;
                ThreadPool.QueueUserWorkItem(x => handler1(@event));
            }
        }
    }

    public interface IHandles<in T>
    {
        void Handle(T message);
    }

    public interface IHandlerRegistry
    {
        void RegisterHandler(Type messageType, Action<IMessage> handler);
    }

    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;

    }
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}
