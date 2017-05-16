# Flyweihgt pattern
정보를 공유하기 위해 공유가능 객체와 그렇지 않는 객체를 분리하고 공유 가능한 정보를 객체 형태로 정의해서 정보 공유를 수행하는 형태의 설계를 Flyweight Pattern이라고 한다.

현재 작정된 코드중 마따힝 Flyweight pattern에 적용할만한게 생각나지 않아서, 스타크래프트에서 유즈맵 세팅을 예로 들었다.
유즈맵 세팅중 유닛 하나만 골라서 게임을 해야하는 경우가 있다.
이때 30초 안에 얼마든지 마린과 파이어뱃을 왔다갔다하며 유닛 정보를 비교하며 선택할 수 있다고 가정해보자.
```cs
while (remainingtime > 0)
{
    Console.WriteLine("Enter 1 or 2");
    Console.WriteLine("1. SmartMarine");
    Console.WriteLine("2. Firebat");
    var key = Console.ReadLine();
    unit = flyweightUnitFactory.GetFlyweight(key == "1" ? typeof(SmartMarine) : typeof(FireBat));
    Console.WriteLine($"Unit type : { unit.GetType().Name}");
    Console.WriteLine($"Unit Max HP : { unit.MaxHp }");

    Console.WriteLine($"Would you like to change unit? [Y/N]");

    key = Console.ReadLine();
    if (key.ToLower() == "n")
        break;
        
    remainingtime = originalTime - Datetime.Now;
}
```
유저가 smartmarine을 선택했다가, firebat을 선택했다가, 다시 마음이 바뀌어 smartmarine을 선택한다고 매번 새로운 객체를
생성해서 해당 유닛의 정보를 보여주는게 아니라, 처음 선택해서, 해당 객체가 Dictionary 같은 컨테이너에 없을 경우 넣어주고, 만약 있으면,
해당 컨테이너에서 꺼내와서 해당 유닛의 정보만 보여주면, 유저가 50번 100번 선택을 바꿔도, 결국 생성된 객체는 마린 1, 파이어뱃 1 로,
쓸대없는데 메모리를 낭비하지 않음으로 메모리를 아낄수 있으며 또한, 가비지 콜렉션되는 것으로부터 성능을 보호할 수 있다.

아래 예제는 처음부터 마린과 파이어뱃을 넣어두고, 꺼내오는 로직만 작성했다.
```cs
public class FlyweightUnitFactory 
{
    private IDictionary<Type, Unit> Flyweights = new Dictionary<Type, Unit>();

    public FlyweightUnitFactory()
    {
        var marine = new SmartMarine();
        var firebat = new FireBat();

        Flyweights.Add(marine.GetType(), marine);
        Flyweights.Add(firebat.GetType(), firebat);
    }
    public Unit GetFlyweight(Type unitType)
    {
        return Flyweights[unitType];
    }
}

```
