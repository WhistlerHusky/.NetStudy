using System;
using System.Linq;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull
{
    public class GreedyReaderPull : IObserverPull
    {
        private int _count;
        private ISubjectPull _subjectPull;
        public string Name { get; set; }

        public GreedyReaderPull(string name, ISubjectPull subjectPull)
        {
            _count = 0;
            Name = name;
            _subjectPull = subjectPull;
            _subjectPull.Register(this);
        }

        public void Update()
        {
            _count++;

            if (_count % 2 == 0)
            {
                UpdateCurrentNews();
            }
        }

        public void UpdateCurrentNews()
        {
            var news = _subjectPull.GetNews();
            Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}");
        }
    }
}
