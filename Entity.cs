using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerExample
{
    public class Entity
    {
        public static string ExampleEvent = "EventManagerExample.Entity.ExampleEvent";

        public string Name;

        public Entity(string name)
        {
            Name = name;

            EventManager.AddListener(ExampleEvent, OnEntityEventReceived);
            Console.WriteLine($"{Name} adds a listener for events named {ExampleEvent}");
        }

        public void BroadcastName()
        {
            Console.WriteLine($"{Name} broadcasts an event...");
            EventManager.InvokeEvent(ExampleEvent, this, EventArgs.Empty);
        }

        public void OnEntityEventReceived(object sender, EventArgs e)
        {
            // Early exit if we're the event sender.
            var s = (Entity)sender;
            if (String.Equals(s.Name, Name)) return;

            Console.WriteLine($"{Name} received an event from {s.Name}");
        }
    }
}