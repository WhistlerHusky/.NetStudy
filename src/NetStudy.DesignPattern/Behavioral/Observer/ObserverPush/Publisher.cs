using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush
{
    public class Publisher : ISubject
    {
        private readonly IList<IObserver> _observers;

        private News _news;

        public string Name { get; set; }

        public Publisher(string name)
        {
            Name = name;

            _observers = new List<IObserver>();
        }

        public void Register(IObserver observer)
        {
            if (_observers.Contains(observer) == false)
            {
                _observers.Add(observer);
            }
        }

        public void UnRegister(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_news);
            }
        }

        public void UpdateNews(News news)
        {
            _news = news;

            NotifyObservers();
        }
    }
}
