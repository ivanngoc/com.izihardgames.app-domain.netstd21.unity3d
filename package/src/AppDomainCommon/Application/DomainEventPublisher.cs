using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IziHardGames.CommonDomain.Contracts;
using IziHardGames.CoreForUnityApp;

namespace IziHardGames.ApplicationLevel
{
    public sealed class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly Dictionary<Type, DomainEventPublishing> keyValuePairs = new Dictionary<Type, DomainEventPublishing>();
        public DomainEventPublisher()
        {
            DomainEventManager.OnSubscription(CreateRouting);
        }

        public void PublishNonGen(Type type, object e)
        {
            var mi = GetType().GetMethod(nameof(Publish));
            var gen = mi.MakeGenericMethod(type);
            gen.Invoke(this, new[] { e });
        }

        public void Publish<T>(T e) where T : IDomainEvent
        {
            if (!keyValuePairs.TryGetValue(typeof(T), out var pub))
            {
                pub = new DomainEventPublishing();
                keyValuePairs.Add(typeof(T), pub);
            }

            if (pub.Subs.Any())
            {
                foreach (var sub in pub.Subs)
                {
                    var obj = sub.handler;
                    var handler = obj as Action<T> ?? throw new InvalidCastException(obj.GetType().AssemblyQualifiedName);
                    handler(e);
                    AfterPublishWork<T>(pub, e);
                }
            }
            else
            {
                DelayPublish<T>(pub);
            }
            pub.lastEvent = e;
        }

        public async Task PublishAsync<T>(T e) where T : IDomainEvent
        {
            if (!keyValuePairs.TryGetValue(typeof(T), out var pub))
            {
                pub = new DomainEventPublishing();
                keyValuePairs.Add(typeof(T), pub);
            }

            if (pub.Subs.Any())
            {
                foreach (var sub in pub.Subs)
                {
                    var obj = sub.handler;
                    var handler = obj as Func<T, Task> ?? throw new InvalidCastException(obj.GetType().AssemblyQualifiedName);
                    await handler(e);
                    AfterPublishWork<T>(pub, e);
                }
            }
            else
            {
                DelayPublish<T>(pub);
            }
            pub.lastEvent = e;
        }

        private void DelayPublish<T>(DomainEventPublishing pub) where T : IDomainEvent
        {

        }

        private void AfterPublishWork<T>(DomainEventPublishing pub, T e) where T : IDomainEvent
        {
            pub.executionCount++;
            for (int i = 0; i < pub.Subs.Count(); i++)
            {
                var sub = pub.Subs.ElementAt(i);
                if (sub.subscriptionType == EEventSubscriptionType.RunOnceForSure)
                {
                    pub.Remove(sub);
                }
            }
        }

        /// <summary>
        /// На одно событие может подписаться несколько источников.
        /// </summary>
        /// <param name="subscription"></param>
        private void CreateRouting(DomainEventSubscription subscription)
        {
            if (keyValuePairs.TryGetValue(subscription.eventType, out var pub))
            {
                pub.Add(subscription);
                if (subscription.subscriptionType == EEventSubscriptionType.RunOnceForSure)
                {
                    PublishNonGen(subscription.eventType, pub.lastEvent);
                }
            }
            else
            {
                pub = new DomainEventPublishing()
                {

                };
                pub.Add(subscription);
                keyValuePairs.Add(subscription.eventType, pub);
            }
        }
    }
}