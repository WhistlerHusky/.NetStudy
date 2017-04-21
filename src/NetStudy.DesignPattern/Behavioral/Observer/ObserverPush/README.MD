# Push
옵저버 패턴을 설명할때 가장 흔하게 이용되는게 이 Push 방법을 이용하는 방법이다.
신문사와 구독자,

```cs
//Metro 신문사 개설
Publisher p = new Publisher("Metro");

//구독자 readerA 생성
IObserver readerA = new ConsoleReader("Reader A");

//구독자가 Metro 신문을 일기 시작함.
p.Register(readerA);
```
Register 메소드로 p의 이벤트를 readerA가 구독하기 시작한다.

이후 새로운 뉴스가 발생하고, p가 이벤트를 발생시키면
```cs
//새로운 뉴스 발생
News news = new News("GitHub", "Github is awesome!");

//Metro 신문사가 뉴스를 획득
//그리고 이벤트 발생.
p.UpdateNews(news);
```

UpdateNews 함수는 아래와 같이 새로운 이벤트를 저장하고, NotifyObserver 함수를 통해
```cs
public void UpdateNews(News news)
{
    _news = news;

    NotifyObservers();
}
```
등록된 모든 옵저버들에게 알려준다.
```cs
public void NotifyObservers()
{
    foreach (var observer in _observers)
    {
        observer.Update(_news);
    }
}
```
이 정보를 어떻게 처리할지는 각각의 옵저버가 알아서 구현한다.
```cs
public class ConsoleReader : IObserver
{
			.
			.
    public void Update(News news)
    {
    	//ConsoleReader의 경우 단순히 Console창에 news를 출력만한다.
        Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}");
    }
}
```
반면 ReverseReader의 경우 뉴스 문자를 모두 뒤집어서 뒤에서 부터 출력한다.
```cs
public class ReverseReader : IObserver
{
			.
			.
    public void Update(News news)
    {
        Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}".Reverse().ToArray());
    }
}
```

다른 책에서는 기상청을 예로 들면서,
동일한 정보(온도)를 화시 혹은 섭씨로 표현하는 2개의 옵저버 Display를 구현했다.

