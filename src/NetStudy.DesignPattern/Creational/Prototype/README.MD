# Prototype pattern
이미 생성된 객체를 복사(deep or shallow copy)해서 생성에 들어가는 비용을 줄인다.
(매번 database에서 객체를 불러오는 비용보단, dictionary나 list에 넣어 놓고 가져오는 비용이 싸게먹힐때가 있다.)

## 1. ICloneable
.Net Framework 에서 Prototype pattern을 사용할때 빠지지 않는것이 바로 이 ICloneable 인터페이스 이다.
```cs
public interface ICloneable
{
    object Clone();
}
```
하지만 .Net Core에서는 해당 인터페이스를 찾을수 없는데 이유는 잠시후에 정리하고, ICloneable이 없음으로 직접 구현해서 사용했다.

```cs
public interface ICloneable
{
    ICloneable Clone();
}

public class Marine : AttackableUnit, ICloneable
{
    public ICloneable Clone()
    {
        var clone = this.MemberwiseClone() as Marine;

        return clone;
    }
}
public class PrototypePatternRunner : IRunner
{
    public void Run()
    {
        var marine = new Marine { Name = "Core Marine" };

        var cloneMarine = marine.Clone() as Marine;

        //The original instance's Name property has changed.
        marine.Name = "Net Marine";

        Console.WriteLine(marine.Name); //Net Marine
        Console.WriteLine(cloneMarine?.Name); // Core Marine
    }
}
```

## 2. ICloneable 의 문제점

 .Net Framework 에서 ICloneable 인터페이스를 구현한 클래스가 Deep copy인지 혹은 Shallow copy인지가 명확하지 않은 문제가 발생한다.
무슨 소리냐면, A라는 클래스가 B라는 클래스를 멤버 변수로 가지고 있다고 하자.
```cs
public class A : ICloneable{
	public B BInstance {get;set;}
    public object Clone()
    {
    	A clone = new A();// 혹은 this.MemberwiseClone() as A 같은 방법으로 복사.
    	clone.BInstance = this.BInstance.Clone(); //이 부분이 Deep copy인지 Shallow copy인지 불분명.
    }
}
```
A.Clone()이 호출되면 내부에서 A멤버에 대한 복사가 이루어 질껏이고, A클래스를 작성한 사람은 이 복사가 Deep 복사 하는것으로 구현했지만,
만약 실제 B 클래스의 Clone은 Shallow copy를 하면, 추후에 문제가 발생할 수 있다.

**실제로 해당 인터페이스는 .Net core에서는 더이상 찾아볼수 없다**