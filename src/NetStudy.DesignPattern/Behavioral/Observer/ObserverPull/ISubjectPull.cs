namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull
{
    public interface ISubjectPull
    {
        void Register(IObserverPull observer);
        void UnRegister(IObserverPull observer);
        void NotifyObservers();

        // 풀방식은 업데이트 된게 있는지 직접 물어보고
        // 있으면 가져와야 함으로 업데이트 존재를 확인할수있는 bool 리턴 함수와
        // 업데이트 된게 있으면 그 정보를 가져올 컨텐츠 리턴형이 필요하다
        bool ExistNews();
        News GetNews();
    }
}
