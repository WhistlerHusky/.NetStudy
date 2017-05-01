# Decorator pattern
주어진 상황 및 용도에 따라 어떤 객체에 책임을 덧붙이는 패턴으로, 기능 확장이 필요할 때 서브클래싱 대신 쓸 수 있는 유연한 대안이 될 수 있다.

여기서는 Strategy pattern에서 사용한 클래스들을 그대로 사용하여 Decorator pattern을 구현하였다.

![alt](https://upload.wikimedia.org/wikipedia/commons/e/e9/Decorator_UML_class_diagram.svg)
<h6 style="text-align: center;" markdown="1">출처 : wikipedia</h6>

AttackableUnit을 Component로 사용 하며
```cs
public abstract class AttackableUnit : Unit
```
SmartMarine 이 여기서는 ConcreteComponent 으로 사용된다.
```cs
public class SmartMarine : AttackableUnit
{
			.
			.
}
```
Decorator 클래스와, 
```cs
public abstract class Decorator : AttackableUnit
{
    protected AttackableUnit _attackableUnit; //이게 핵심.

    protected Decorator(AttackableUnit attackableUnit)
    {
        _attackableUnit = attackableUnit;
    }
}
```
이 클래스를 상속 구현하는 Stimpack class (ConcreteDecorato )
```cs
public class Stimpack : Decorator
{
    public Stimpack(AttackableUnit smartMarine) : base(smartMarine)
    {
        _hp = smartMarine.HP;
        Name += "Stimpack " + smartMarine.Name;
        Console.WriteLine($"'{smartMarine.Name} uses stimpack'");
    }
	public override void Attack(Unit unit)
    {
        base.Attack(unit);
        base.Attack(unit);
    }
}
```

SmartMarine이 Stimpack을 사용하는 방법은 아래와 같다.
```cs
SmartMarine smartMarine = new SmartMarine(gun);
smartMarine.Name = "Smart Marine B";

Decorator stimpackMarine = new Stimpack(smartMarine);
stimpackMarine.Attack(stupidMarine);
```
이러면 공격이 두번씩 나간다.

ConcreteComponent는(SmartMarine) ConcreteComponent를 첨가물로 추가할순 없다(두번이상 겹칠수 없다)
즉, 마린을 마린으로 감쌀순 없다.

ConcreteDecorator은 여러번 겹칠수 있다. (현재 스팀팩을 또 스팀팩으로 감쌀수 있는건 문제가 될수도있다...이건 다른 패턴에서 다시 손보자!)


