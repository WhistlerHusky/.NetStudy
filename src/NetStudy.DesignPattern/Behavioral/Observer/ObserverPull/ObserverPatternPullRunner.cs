using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull
{
    public class ObserverPatternPullRunner : IRunner
    {
        public void Run()
        {
            //Metro 신문사 개설
            PublisherPull p = new PublisherPull("Metro");

            //구독자 Greedy 생성
            GreedyReaderPull greedyReaderPull = new GreedyReaderPull("GreedyReader B", p);

            //구독자 Relaxed 생성
            RelaxedReaderPull relaxedReaderPull = new RelaxedReaderPull("RelaxedReader A", p);

            //1시간 경과
            News news = new News("12:00 pm Exchange Rate US - > WON", "1000");
            p.UpdateNews(news);

            //2시간 경과 // greedyReaderPull 출력
            news = new News("13:00 pm Exchange Rate US - > WON", "1100");
            p.UpdateNews(news);

            news = new News("14:00 Exchange Rate US - > WON", "1200");
            p.UpdateNews(news);

            //4시간 경과 // greedyReaderPull 출력
            news = new News("15:00 Exchange Rate US - > WON", "1300");
            p.UpdateNews(news);

            //5시간 경과 // relaxedReaderPull 출력
            news = new News("16:00 Exchange Rate US - > WON", "1400");
            p.UpdateNews(news);

            //6시간 경과 // greedyReaderPull 출력
            news = new News("15:00 Exchange Rate US - > WON", "1500");
            p.UpdateNews(news);

            //7시간 경과
            news = new News("16:00 Exchange Rate US - > WON", "1600");
            p.UpdateNews(news);

            //비록 7시간 밖에 경과안했지만, relaxedReader, greedyReaderPull 둘다 퇴근하기전 현재 환율을 보고싶어서
            //pull 방식으로 가져옴.
            greedyReaderPull.UpdateCurrentNews();
            relaxedReaderPull.UpdateCurrentNews();
        }
    }
}
