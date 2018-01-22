# Mediator pattern

보통 한 프로젝트(프로그램)에 수많은 클래스로 만들어진다. 이렇게 클래스가 많아질수록 클래스간의 의사소통이(커플링) 복잡해 지는데
이는 유지보수나 리펙토링을 할 때에 많은 고생을 하게된다. Mediator pattern은 이런 클래스간에 중계기를 하나두고 모두 이 중계기를 통해 의사소통을 하게 함으로서,
커플링을 줄일수있다. 다만 모두 중계기를 통해 의사소통을 하게됨으로 중계기가 아주 크지게 될 경우가 발생한다.

예전에 월드오브 워크래프트 온라인에서 종족이 다르면 서로 채팅이 이상하게 보인다고 들은적이 있다.
여기서는 그냥 똑똑한 마린과, 멍청한 마린은 서로 대화가 안통한다는 가정하에 코딩을 했다.

먼저 SpeakableUnit 클래스를 추가해서 해당 클래스를 상속받는 마린들은 듣고 말할수 있게 기능을 추가하고.
(여기서는 Speak 부분만 Mediator 클래스를 통하게끔 하였다.)
```csharp
public abstract class SpeakableUnit : AttackableUnit
{
    public Mediator Mediator { get; set; }

    public void Speak(string message)
    {
        Mediator.Speak(this, message);
    }

    public void Hear(Unit fromUnit, string message)
    {
        Console.WriteLine($"{Name} heard {fromUnit.Name} say {message}");
    }
}
public class SpeakableSmartMarine : SpeakableUnit {}
public class SpeakableStupidMarine : SpeakableUnit{}
```

Mediator 클래스는 아래와 같이
```csharp
 public class Mediator
 {
     private IList<SpeakableUnit> _units;

     public Mediator()
     {
         _units = new List<SpeakableUnit>();
     }

     public void Register(SpeakableUnit unit)
     {
         if (_units.IndexOf(unit) < 0)
         {
             _units.Add(unit);

             unit.Mediator = this;
         }
     }

     public void Speak(Unit unit, string message)
     {
         foreach (var unitInUnits in _units)
         {
             if (unitInUnits == unit)
             {
                 continue;
             }

             if (unit.GetType() == unitInUnits.GetType())//같은 타입의 클래스만 메시지가 똑바로 출력되고
             {
                 unitInUnits.Hear(unit, message);
             }
             else // 아니면 메시지가 뒤집혀서 출력.
             {
                 unitInUnits.Hear(unit, new string(message.ToCharArray().Reverse().ToArray()));
             }
         }
     }
 }

```
실행부분 먼저 멍청한 마리 2마리와, 똑똑한 마린 2마리를 생성해서 중계기에 넣어준다.
그리고 "멍청한 마린이1" 말을 하면 "멍청한 마린2"에게만 정상적인 메시지가 출력되고, 똑똑한 마린에게는 뒤집혀진 메시지가 출력된다.

반대로 "똑똑한 마린이 1" 이 What? 이라고 하면 멍청한 마린 1,2 에겐 "?tahW" 이라고 출력되고, 똑같은 타입의 똑똑한 마린 1에게만
"Waht?" 이라고 정상 출력된다.

```csharp
public void Run()
{
    var stupidMarine1 = new SpeakableStupidMarine();
    stupidMarine1.Name = "Sutpid Marine 1";

    var stupidMarine2 = new SpeakableStupidMarine();
    stupidMarine2.Name = "Sutpid Marine 2";

    var smartMarine1 = new SpeakableSmartMarine();
    smartMarine1.Name = "Smart Marine 1";

    var smartMarine2 = new SpeakableSmartMarine();
    smartMarine2.Name = "Smart Marine 2";
    Mediator mediator = new Mediator();

    mediator.Register(stupidMarine1);
    mediator.Register(stupidMarine2);
    mediator.Register(smartMarine1);
    mediator.Register(smartMarine2);

    stupidMarine1.Speak("I'm a stupid marine");

    smartMarine1.Speak("What? ");
}

```

여기에서는 Speakable 을 상속받는걸로 구현했지만, 사실 아래와 같이 zerg나 terran을 추가해도 상관없다. 이 두 클래스는 Mediator에만 추가될 껏임으로
Speakable 을 상속받는 클래스들은 저 두 클래스에 대한 reference가 필요치 않다.
```csharp
public class Mediator
{
    //private IList<Terran> _terranUnits;
    //private IList<Zerg> _zergUnits;

    private IList<SpeakableUnit> _units;
}  
```