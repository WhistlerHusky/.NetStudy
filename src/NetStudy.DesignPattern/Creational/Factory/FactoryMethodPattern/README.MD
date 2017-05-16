# Factory Method Pattern

factory method 패턴은 객체를 생성하는 시점은 알지만 어떤 객체를 생성해야 할지 알 수 없을 때, 객체 생성후 처리해야되는 일이 있을때, 매번 생성하는 코드에 반복되는 코드를 없애고, 객체 생성을 담당하는 하위 클래스에 위임하여 해결한다.
e.g. 마린을 생성하는건 알지만, 한국 마린이냐 미국 마린이냐 를 모를때 객체 생성을 하위 클래스에 위임하여 해결 할 수 있다.

추상 마린 팩토리를 만들고.
```cs
public abstract class MarineFactory
{
    public abstract AttackableUnit CreateMarine(string marineType);
}
```

실제 객체 생성은 하위 클래스에서 구현.
```cs
//한국 해병
public class KoreanMarineFactory : MarineFactory
{
    public override AttackableUnit CreateMarine(string marineType)
    {
        AttackableUnit marine = null;

        switch (marineType)
        {
            case "1":
                marine = new KoreanFlyingMarine();
                break;
            case "2":
                marine = new KoreanSmartMarine();
                break;
            default:
                throw new NotImplementedException("There are only 2 types, 1 and 2");
        }

        return marine;
    }
}
```
//미국 해병
```cs
public class UsaMarineFactory : MarineFactory
{
    public override AttackableUnit CreateMarine(string marineType)
    {
        AttackableUnit marine = null;

        switch (marineType)
        {
            case "1":
                marine = new UsaFlyingMarine();
                break;
            case "2":
                marine = new UsaSmartMarine();
                break;
            default:
                throw new NotImplementedException("There are only 2 types, 1 and 2");
        }

        return marine;
    }
}
```
```cs
public class FactoryMethodPatternRunner : IRunner
{
    public void Run()
    {
        //아래 부분을 유저 input을 통해 한국 혹은 미국 MarineFactory를 만들수도있다.
        MarineFactory koreanMarineFactory = new KoreanMarineFactory();
        MarineFactory usaMarineFactory = new UsaMarineFactory();
        
        var koreanMarine1 = koreanMarineFactory.CreateNewMarine("1");
        var usaMarine = usaMarineFactory.CreateNewMarine("1");

        Console.WriteLine(koreanMarine1.GetType().Name);
        Console.WriteLine(usaMarine.GetType().Name);
        
        //이렇게 같은 리스트에 담을수도 있다.
        IList<AttackableUnit> marineList = new List<AttackableUnit>();
        marineList.Add(koreanMarine1);
        marineList.Add(usaMarine);
    }
}

```

위 코드에서는 생성만 팩토리 메소드 패턴으로 구현하였지만, 생성후에 매번 처리해야 하는 코드를 팩토리에 넣어주면,
매번 마린을 생성하는 코드에서 반복되는 코드를 해결 할 수 있다.
e.g. 마린 currentHp 설정.
```cs
public AttackableUnit CreateNewMarine(string marineType)
{
    var marine = CreateMarine(marineType);
    marine.CurrentHp = 40;

    return marine;
}
public abstract AttackableUnit CreateMarine(string marineType);
```
위와 같이 했을경우 물론 호출은 CreateMarine 함수가 아닌 CreateNewMarin 함수를 호출해야된다.