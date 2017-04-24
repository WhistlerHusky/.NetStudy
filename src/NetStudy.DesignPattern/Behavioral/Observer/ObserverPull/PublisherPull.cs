using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull
{
    public class PublisherPull : ISubjectPull
    {
        private readonly IList<IObserverPull> _observers;

        private Observer.News _news;

        public string Name { get; set; }

        public PublisherPull(string name)
        {
            Name = name;

            _observers = new List<IObserverPull>();
        }

        public void Register(IObserverPull observer)
        {
            if (_observers.Contains(observer) == false)
            {
                _observers.Add(observer);
            }
        }

        public void UnRegister(IObserverPull observer)
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
                observer.Update();
            }
        }

        public bool ExistNews()
        {
            return _news != null;
        }

        public Observer.News GetNews()
        {
            return _news;
        }

        public void UpdateNews(Observer.News news)
        {
            _news = news;

            NotifyObservers();
        }
    }
}
