# Visitor pattern
> 객체의 구조와 기능을 분리시켜 구조는 변경하지 않으면서 기능만을 따로 추가, 확장되어야 할 경우에 사용되는 패턴이다.

스타크래프트에서 만약 유닛을 여러마리 선택했을때 HP만 보고싶다거나 혹은 이름과 HP만을 보고싶다고 가정해보자,
유닛을 선택할때 List로 그 유닛을 선택하는 구조는 동일하지만, 그 유닛에 대한 정보를 보여주는 기능을 다르게 하고 싶을때 사용 할 수 있는게 바로 이 Visitor pattern이다.


```csharp
public interface IVisitor
{
    void Visit(Unit unit);
}
```
```csharp
//이름만 출력하는 Visitor
public class UnitNameVisitor : IVisitor
{
    public void Visit(Unit unit)
    {
        Console.WriteLine($"{unit.Name}");
    }
}
```

```csharp
//이름과 HP를 같이 출력하는 Visitor
public class UnitNameAndHpVisitor : IVisitor
{
    public void Visit(Unit unit)
    {
        Console.WriteLine($"{unit.Name} hp => {unit.CurrentHp}");
    }
}
```
여기서는 unit들을 리스트로 보관하는 구조이다.
```csharp
public class Units
{
    private IList<Unit> _units = new List<Unit>();

    public void Attach(Unit unit)
    {
        _units.Add(unit);
    }
    public void Detach(Unit unit)
    {
        _units.Remove(unit);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (Unit u in _units)
        {
            visitor.Visit(u);
        }
    }
}
```

```csharp
AttackableUnit stupidMarine1 = new StupidMarine();
stupidMarine1.Name = "StupidMarine1";
AttackableUnit stupidMarine2 = new StupidMarine();
stupidMarine2.Name = "StupidMarine2";
AttackableUnit smartMarine1 = new SmartMarine();
smartMarine1.Name = "SmartMarine1";
AttackableUnit smartMarine2 = new SmartMarine();
smartMarine2.Name = "SmartMarine2";

//여기 코드는 단순히 서로 다른 HP를 보여주기위해서
stupidMarine1.Attack(stupidMarine2);
stupidMarine1.Attack(stupidMarine2);
smartMarine1.Attack(smartMarine2);
smartMarine1.Attack(smartMarine2);
smartMarine1.Attack(smartMarine2);

//비지터가 방문할 유닛들을 한군데 모으고
Units units = new Units();
units.Attach(stupidMarine1);
units.Attach(stupidMarine2);
units.Attach(smartMarine1);
units.Attach(smartMarine2);
Console.WriteLine("");

//이름과 HP를 같이보여주는 Visitor
IVisitor visitor = new UnitNameAndHpVisitor();
units.Accept(visitor);
Console.WriteLine("");
```
```
StupidMarine1 hp => 40
StupidMarine2 hp => 30
SmartMarine1 hp => 40
SmartMarine2 hp => 25
```
```csharp
//이름만 보여주는 Visitor
visitor = new UnitNameVisitor();
units.Accept(visitor);
```
```
StupidMarine1
StupidMarine2
SmartMarine1
SmartMarine2
```
