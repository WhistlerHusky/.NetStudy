using System;
using System.Linq;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush
{
    /// <summary>
    /// 원래 Trace로 writeline 하려구 했는데, Core에 Trace가 없음..
    /// </summary>
    public class ReverseReader : IObserver
    {
        public string Name { get; set; }

        public ReverseReader(string name)
        {
            Name = name;
        }

        public void Update(ObserverPull.News news)
        {
            Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}".Reverse().ToArray());
        }
    }
}
