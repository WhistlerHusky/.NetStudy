using System;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull
{
    public class RelaxedReaderPull : IObserverPull
    {
        private int _count;

        private ISubjectPull _subject;
        public string Name { get; set; }

        public RelaxedReaderPull(string name, ISubjectPull subject)
        {
            Name = name;
            _count = 0;
            _subject = subject;
            subject.Register(this);
        }

        public void Update()
        {
            _count++;

            if (_count % 5 == 0)
            {
                UpdateCurrentNews();
            }
        }

        public void UpdateCurrentNews()
        {
            var news = _subject.GetNews();

            Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}");

        }

        public void StopGettingNews()
        {
            _subject?.UnRegister(this);
        }
    }
}
