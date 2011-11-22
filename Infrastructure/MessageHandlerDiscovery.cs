using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class MessageHandlerDiscovery
    {
        readonly IHandlerRegistry _registry;

        public MessageHandlerDiscovery(IHandlerRegistry registry)
        {
            _registry = registry;
        }

        public void AddMessageReciever(object reciever)
        {
            var messageTypes = GetAllMessageTypes(reciever);
            foreach (var messageType in messageTypes)
            {
                var action = CreateCallToHandleAction(reciever, messageType);
                _registry.RegisterHandler(messageType, action);
            }
        }

        /// <summary>
        /// Creates lambda action: "IMessage is MessageType"
        /// Func[IMessage]: message => reciever.Handle((MessageType)message);
        /// </summary>
        static Action<IMessage> CreateCallToHandleAction(object reciever, Type messageType)
        {
            var sourceParameter = Expression.Parameter(typeof (IMessage), "source");
            var methodInfo = reciever.GetType().GetMethod("Handle", new[] {messageType});
            var result = Expression.Lambda<Action<IMessage>>(
                Expression.Call(
                    Expression.Constant(reciever),
                    methodInfo,
                    new[] {Expression.Convert(sourceParameter, messageType)}), sourceParameter);

            var action = result.Compile();
            return action;
        }

        static IEnumerable<Type> GetAllMessageTypes(object reciever)
        {
            return reciever.GetType().GetInterfaces()
                .Where(ImplementsHandles)
                .Select(i => i.GetGenericArguments().First());
        }

        static bool ImplementsHandles(Type x)
        {
            return x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IHandles<>);
        }
    }
}