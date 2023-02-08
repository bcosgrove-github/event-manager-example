using System;

namespace EventManagerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Entity("Entity A");
            var b = new Entity("Entity B");
            var c = new Entity("Entity C");
            Console.WriteLine("");

            a.BroadcastName();
            Console.WriteLine("");

            b.BroadcastName();
            Console.WriteLine("");

            c.BroadcastName();
            Console.WriteLine("");

            Console.Read();
        }
    }
}
