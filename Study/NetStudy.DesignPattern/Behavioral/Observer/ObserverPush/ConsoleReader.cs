using System;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush
{
    public class ConsoleReader : IObserver
    {
        public string Name { get; set; }

        public ConsoleReader(string name)
        {
            Name = name;
        }

        public void Update(ObserverPull.News news)
        {
            Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}");
        }
    }
}
