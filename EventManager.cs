using System;
using System.Collections.Generic;

namespace EventManagerExample
{
    public class EventManager
    {
        private static EventManager instance;
        private Dictionary<string, EventHandler<EventArgs>> events = new Dictionary<string, EventHandler<EventArgs>>();

        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManager();
                }

                return instance;
            }
        }
        public static void AddListener(string eventName, EventHandler<EventArgs> listener)
        {
            if (Instance.events.ContainsKey(eventName))
            {
                Instance.events[eventName] += listener;
            }
            else
            {
                Instance.events.Add(eventName, listener);
            }
        }

        public static void RemoveListener(string eventName, EventHandler<EventArgs> listener)
        {
            if (Instance.events.ContainsKey(eventName))
            {
                Instance.events[eventName] -= listener;
            }
        }

        public static void InvokeEvent(string eventName, object sender, EventArgs e)
        {
            Instance.events[eventName]?.Invoke(sender, e);
        }
    }
}