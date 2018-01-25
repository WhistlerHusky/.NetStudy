namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush
{
    public interface ISubject
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);
        void NotifyObservers();
    }
}
