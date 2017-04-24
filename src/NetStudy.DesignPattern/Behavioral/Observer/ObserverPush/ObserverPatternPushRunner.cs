using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush
{
    public class ObserverPatternPushRunner : IRunner
    {
        public void Run()
        {
            //Metro 신문사 개설
            Publisher p = new Publisher("Metro");

            //구독자 readerA 생성
            IObserver readerA = new ConsoleReader("Reader A");

            //구독자가 Metro 신문을 일기 시작함.
            p.Register(readerA);

            //새로운 뉴스 발생
            ObserverPull.News news = new ObserverPull.News("GitHub", "Github is awesome!");

            //Metro 신문사가 뉴스를 획득
            //그러면 안에서 구독자에게 자동으로 신문이 발행됨.
            p.UpdateNews(news);

            //새로운 구독자 readerB 생성
            IObserver readerB = new ConsoleReader("Reader B");
            //readerB도 Metro 구독 시작
            p.Register(readerB);

            //새로운 뉴스 발생
            news = new ObserverPull.News("GitHub", "Github is getting even better!");

            //Metro 신문사가 뉴스를 획득
            p.UpdateNews(news);

            //구독자 Reader A가 구독을 중지함
            p.UnRegister(readerA);
            
            //새로운 뉴스 발행
            news = new ObserverPull.News("Github","Open source is awesome!");

            //Metro 신문사가 뉴스를 획득
            p.UpdateNews(news); //Reader B만 뉴스를 획득함.

            //뉴스를 꺼구로 읽는 ReverseReader A 생성
            IObserver reverseReader = new ReverseReader("ReverseReader A");
            
            //Metro 뉴스 구독 시작
            p.Register(reverseReader);

            //새로운 뉴스 발생
            news = new ObserverPull.News("Github","Server Down!");

            //Metro 신문사가 뉴스를 획득
            p.UpdateNews(news);
        }
    }
}
