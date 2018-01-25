# Pull
Pull 방법에서는 흔히 observer 또한 subject을 멤버변수로 가진다.
```csharp
public class GreedyReaderPull : IObserverPull
{
    private ISubjectPull _subjectPull;
			.
			.
	public GreedyReaderPull(string name, ISubjectPull subjectPull)
	{
				.
				.
            _subjectPull = subjectPull;
            _subjectPull.Register(this);
    }
}
```

그리고 Observer가 언제든지 새로운 뉴스가 있는지 체크를 한 이후 새로운 뉴스가 있을경우 이를 받아오면된다.
```csharp
//pull 방식으로 가져옴.
greedyReaderPull.UpdateCurrentNews();
```
```csharp
public void UpdateCurrentNews()
{
    var news = _subjectPull.GetNews();
    Console.WriteLine($"{Name} got new news {news.Title} - {news.Body}");
}
```
Pull이 가능한 이뉴는 멤버변수로 Publisher의 객체를 가지고 있기 때문이다.

물론 새로운 정보가 있을때마다 Push방법으로 정보를 받을수도 있다.
GreedyReaderPull은 새로운 정보가 2번 있을때마다 한번 받아보고,
RelaxedReaderPull은 5번에 한번씩 정보를 받아보는 코드이다.
```csharp
/// GreedyReaderPull 의 Update
public void Update()
{
    _count++;

    if (_count % 5 == 0)
    {
        UpdateCurrentNews();
    }
}

/// RelaxedReaderPull은 의 Update
public void Update()
{
    _count++;

    if (_count % 5 == 0)
    {
        UpdateCurrentNews();
    }
}
```

마지막으로 Push 방법에서는 Publisher만이 구독 해지가 가능했지만 (구독자가 신문사에 접근할 수 있는 객체를 멤버로 가지고 있지 않아서)
Pull 방식에서는 언제든지 구독을 구독자가 그만둘수 있다.
```csharp
public void StopGettingNews()
{
    _subject?.UnRegister(this);
}
```
마지막 코드는 예제에는 없다.