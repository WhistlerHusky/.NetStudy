# Simple Factory Pattern

팩토리 패턴은 객체를 생성하는 부분을 한곳에 모아서 관리를 용이하게 하기 위해 사용한다.

일단 StrategyPatternRunner.cs 을 보자.
```cs
public class StrategyPatternRunner : IRunner
   {
       public void Run()
       {
           IWeapon gun = new Gun();

           //멍청한 마린
           StupidMarine stupidMarine = new StupidMarine();
           stupidMarine.Name = "StupidMarine";
            //똑똑한 마린
           SmartMarine smartMarine = new SmartMarine(gun);
           smartMarine.Name = "SmartMarine";
				.
				.
	}
}
```
Strategey pattern에서는 마린 생성부분을 하드코드로 해뒀지만 만약 사용자의 입력을 받고, 그에 따라 Smart마린과 Super마린을 동적으로 생성한다고 가정해보자.
**StupidMarine은 Attackable 을 상속하지 않아서 여기서 같이 사용할수가 없어서 SuperMarine을 새로 만듬.**
```cs
 public class SuperMarine : AttackableUnit
 {
     public SuperMarine(IWeapon weapon)
     {
         _currentHp = 60;

         _weapon = weapon;
     }
			.
			.
}
```

```cs
IWeapon gun = new Gun();

Console.WriteLine("Enter either 1 or 2 to create mainA: 1. SmartMarine 2. SuperMarine");
var userInput = Console.ReadLine();
AttackableUnitMarineA =null;

switch (userInput)
{
    case "1":
       MarineA = new SmartMarine(gun);
       MarineA.Name = "SmartMarine A";
        break;
    case "2":
        MarineA= new SuperMarine(gun);
        MarineA.Name = "SuperMarine A";
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
 }
```
사용자가 1을 입력하면 SmartMarine type의 객체가 2을 입력하면 SuperMarine type의 객체가 생성될것이다.

그리고 마린 B를 또 만든다고 해보자. 위와 동일하게 입력을 받아MarineB에 대입할것이다.
```cs
Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarine 2. SuperMarine");
userInput = Console.ReadLine();
AttackableUnitMarineB = null;

switch (userInput)
{
    case "1":
       MarineB = new SmartMarine(gun);
       MarineA.Name = "SmartMarine B";
        break;
    case "2":
       MarineB = new SuperMarine(gun);
       MarineA.Name = "SuperMarine B";
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
}
```
위 두 코드를 보면 거의 중복임을 알 수있다.
그럼 함수로 만들어보자.

```cs
private AttackableUnit CreateMarine(stringMarineName)
{
    IWeapon gun = new Gun();

    Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarine 2. SuperMarine");
    var userInput = Console.ReadLine();
    AttackableUnitMarine = null;

    switch (userInput)
    {
        case "1":
           marine = new SmartMarine(gun);
           marine.Name = "Smart " +MarineName;
            break;
        case "2":
           marine = new SuperMarine(gun);
           marine.Name = "Super" +MarineName;
            break;
        default:
            throw new NotImplementedException("Wrong input entered");
    }

    returnMarine;
}
```

그러면 run 함수는 아래와 같이 짧아졌다.
```cs
public void Run()
{
    AttackableUnitMarineA = CreateMarine("Marine A");
    AttackableUnitMarineB = CreateMarine("Marine B");

    while (MarineA.CurrentHp > 0 &&MarineB.CurrentHp > 0)
    {
       MarineA.Attack(MarineB);
        Console.WriteLine();

       MarineB.Attack(MarineA);
        Console.WriteLine();
    }

    var winner =MarineA.CurrentHp > 0 ?MarineA.Name :MarineB.Name;

    Console.WriteLine($"The winner is {winner}");
}
```
함수로 고쳤고, 코드 중복도 없어보인다. 문제가 없는것일까?
1. 이 함수가 여기에 있는게 맞을까?
2. 나중에 FlyingMarine를 추가하기 위해, 이 클래스를 변경하는게 맞을까?

먼저 1번을 생각해보자.
만약 추후에 다른 클래스에서도 유저 입력에 따라 마린을 생성한다고 가정해보자.
그곳에 또 CreateMarine 함수를 만들것인가? (함수 중복)

그럼 2번을 생각해보자.
만약 FlyingMarine이 추가되면, 여기에 있는 CreatMarine 함수와, 다른곳에 새로 생긴 CreatMarine 두곳에 다
아래와 같은 코드를 추가해야된다. (CreatMarine 함수가 존재하는곳 다 찾아서 수정해야함)
```cs
case "3":
   marine = new FlyingMarine(gun);
   marine.Name = "Flying " +MarineName;
    break;
```
이럴때 사용하는게 Factory pattern이다.
**객체를 생성하는 부분을 한곳에 모아서 관리를 용이하게 하기 위해 사용한다.**
아래와 같이 Factory 클래스를 하나 생성하면
```cs
public class MarineFactory
{
    public static AttackableUnit CreateMarine(stringMarineName)
    {
        IWeapon gun = new Gun();

        Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarine 2. SuperMarine");
        var userInput = Console.ReadLine();
        AttackableUnitMarine = null;

        switch (userInput)
        {
            case "1":
               marine = new SmartMarine(gun);
               marine.Name = "Smart " +MarineName;
                break;
            case "2":
               marine = new SuperMarine(gun);
               marine.Name = "Flying " +MarineName;
                break;
            default:
                throw new NotImplementedException("Wrong input entered");
        }

        returnMarine;
    }
}
```
1번 문제가 해결된다. 언제 어디서든MarineFactory.CreateMarine 함수를 호출하면 간단하게Marine을 생성할수있다.
```cs
AttackableUnitMarineA =MarineFactory.CreateMarine("Marine A");
AttackableUnitMarineB =MarineFactory.CreateMarine("Marine B");
```
또 한 2번문제 FlyingMarine을 추가해야 할 경우MarineFactory.CreatMarine 함수 한군데만 수정하면 된다.
```cs
switch (userInput)
{
    case "1":
       marine = new SmartMarine(gun);
       marine.Name = "Smart " +MarineName;
        break;
    case "2":
       marine = new SuperMarine(gun);
       marine.Name = "Super " +MarineName;
        break;
    case "3":
       marine = new FlyingMarine(gun);
       marine.Name = "Flying " +MarineName;
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
}
```
지금은 함수 내부에서 유저의 입력을 받지만 보통 유저의 입력은 밖에서 받고
CreatMarine 함수 호출할때 인자로 인풋을 보내는게 일반적이다.
```cs
Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarine 2. SuperMarine");
var userInput = Console.ReadLine();
AttackableUnitMarineA =MarineFactory.CreateMarine(userInput, "Marine A");
```
그리고 여기서는 string 으로 case문을 작성했는데, string보다는 enum을 사용하면 실수를 방지할 수 있다.
예를들어 4를 입력받으면 InvisibleMarine을 만들려고 하다가 실수로 4가 아닌 44을 하드코딩했다고 가정하자
```cs
case "44":
   marine = new InvisibleMarine(gun);
   marine.Name = "Invisible " +MarineName;
    break;
```
추후에 유저가 4를 입력하면 런타임 에러 NotImplementedException("Wrong input entered"); 가 발생할것이다.
이런 실수를 방지하기 위해 enum을 사용하는게 더 효율적이다.
```cs
public enumMarineType
{
	SmartMarine = 1,
	SuperMarine = 2,
	FlyingMarine = 3,
	InvisibleMarine = 4,
}
```
그러면 스위치 문도
```cs
switch (userInput) //물론 userInputMarineType enum type이여야 한다.
{
    caseMarineType.SmartMarine:
       marine = new SmartMarine(gun);
       marine.Name = "Smart " +MarineName;
        break;
    caseMarineType.SuperMarine:
       marine = new SuperMarine(gun);
       marine.Name = "Super " +MarineName;
        break;
    caseMarineType.FlyingMarine:
       marine = new FlyingMarine(gun);
       marine.Name = "Flying " +MarineName;
        break;
    caseMarineType.InvisibleMarine:
       marine = new InvisibleMarine(gun);
       marine.Name = "Flying " +MarineName;
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
}
```
그외에도 Reflection을 사용하면 case도 줄일수 있을듯하다...(물론 오버킬이긴 하다...)