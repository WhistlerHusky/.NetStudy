namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush
{
    public interface IObserver
    {
        void Update(ObserverPull.News news);
    }
}
