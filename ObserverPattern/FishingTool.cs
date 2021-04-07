using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    /// <summary>
    /// rod tool is a abstract class
    /// It maintain subscriber list and inform subscribers
    /// </summary>
    public abstract class FishingTool
    {
        private readonly List<ISubscriber> _subscribers;

        protected FishingTool()
        {
            _subscribers = new List<ISubscriber>();
        }

        public void AddSubcriber(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
                _subscribers.Add(subscriber);
            
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
                _subscribers.Remove(subscriber);
        }

        public void Notify(FishType type)
        {
            foreach (var subscriber in _subscribers)
                subscriber.Update(type);
        }
    }
}
