# Memento pattern

>메멘토 패턴(Memento Pattern)은 개체의 상태를 기억해 놓았다가 원래 상태로 복원을 할 필요가 있을 때 기록해 놓은 것을 사용하는 패턴이다. 메멘토 패턴은 실행 취소 기능(undo)을 지원하고자 할 때 많이 사용된다.


실행 취소 반복 하면 떠오르는 또 다른 패턴이 바로 Command pattern 인데 차이점은 무엇일까?

##1. Command pattern
Command pattern 은 보통 행위(method)를 undo, redo 함으로 각 행위를 저장해뒀다가 여러번 undo, redo 할수 있다. 그래서 해당 객체 레프런스만 가지고 실행이 가능하다.

##2. Memento pattern
Memento pattern은 상태(value, reference)를 undo, redo 하기 때문에 여러번 반복 하기엔  상태값들을 너무많이 저장해야한다.

먼저 여기에서만 사용됨으로 Extension 클래스를 통해 Unit클래스의 기능을 확장한다.
```cs
public static class MementoExtensionHelper
{
    public static Memento CreateMemento(this Unit unit)
    {
        return new Memento{ CurrentHp =  unit.CurrentHp, MaxHp = unit.MaxHp, Name = unit.Name};
    }

    public static void RestoreMemento(this Unit unit, Memento memento)
    {
        unit.Name = memento.Name;
        unit.CurrentHp = memento.CurrentHp;
        unit.MaxHp = memento.MaxHp;
    }
}
```
이제 Unit을 상속받는 모든 클래스는 최소한 Name, CurrentHp, MaxHp는 Memento pattern을 활용할수 있다.

##3. 사용법
SmartMarine 을 생성한 이후, Memento(복원할 지점)을 정한다.
```cs
AttackableUnit smartMarin = new SmartMarine();
smartMarin.Name = "Smart Marine";

//Create memento obj before fighting.
var ct = new CareTaker();
ct.Memento = smartMarin.CreateMemento();
```

StupidMarine에게 공격을 받아 hp가 5밖에 남지않는다.
```cs
for (int i = 0; i < 7; i++)
{
    stupidMarine.Fire(smartMarin);
}

Console.WriteLine($"Current smart marine hp = {smartMarin.CurrentHp}");
Console.WriteLine();
```
```
Smart Marine got attacked! 40 -> 35
Smart Marine got attacked! 35 -> 30
Smart Marine got attacked! 30 -> 25
Smart Marine got attacked! 25 -> 20
Smart Marine got attacked! 20 -> 15
Smart Marine got attacked! 15 -> 10
Smart Marine got attacked! 10 -> 5
Current smart marine hp = 5
```

하지만 이렇게 CareTaker를 통해 복원이 가능하다.
```cs
smartMarin.RestoreMemento(ct.Memento);
Console.WriteLine($"smart marine hp after restoring memento = {smartMarin.CurrentHp}");
```
```
smart marine hp after restoring memento = 40
```
