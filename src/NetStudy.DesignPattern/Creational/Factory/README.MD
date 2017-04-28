# Factory Pattern

팩토리 패턴은 객체를 생성하는 부분을 한곳에 모아서 관리를 용이하게 하기 위해 사용한다.

일단 StrategyPatternRunner.cs 을 보자.
```cs
public class StrategyPatternRunner : IRunner
   {
       public void Run()
       {
           IWeapon gun = new Gun();

           //멍청한 마린
           StupidMarin stupidMarin = new StupidMarin();
           stupidMarin.Name = "Stupid Marin";
            //똑똑한 마린
           SmartMarin smartMarin = new SmartMarin(gun);
           smartMarin.Name = "Smart Marin";
				.
				.
	}
}
```
Strategey pattern에서는 마린 생성부분을 하드코드로 해뒀지만 만약 사용자의 입력을 받고, 그에 따라 Smart마린과 Super마린을 동적으로 생성한다고 가정해보자.
**StupidMarin은 Attackable 을 상속하지 않아서 여기서 같이 사용할수가 없어서 SuperMarin을 새로 만듬.**
```cs
 public class SuperMarin : AttackableUnit
 {
     public SuperMarin(IWeapon weapon)
     {
         _hp = 60;

         _weapon = weapon;
     }
			.
			.
}
```

```cs
IWeapon gun = new Gun();

Console.WriteLine("Enter either 1 or 2 to create mainA: 1. SmartMarin 2. SuperMarin");
var userInput = Console.ReadLine();
AttackableUnit marinA =null;

switch (userInput)
{
    case "1":
        marinA = new SmartMarin(gun);
        marinA.Name = "Smart Marin A";
        break;
    case "2":
         marinA= new SuperMarin(gun);
         marinA.Name = "Super Marin A";
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
 }
```
사용자가 1을 입력하면 SmartMarin type의 객체가 2을 입력하면 SuperMarin type의 객체가 생성될것이다.

그리고 마린 B를 또 만든다고 해보자. 위와 동일하게 입력을 받아 marinB에 대입할것이다.
```cs
Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
userInput = Console.ReadLine();
AttackableUnit marinB = null;

switch (userInput)
{
    case "1":
        marinB = new SmartMarin(gun);
        marinA.Name = "Smart Marin B";
        break;
    case "2":
        marinB = new SuperMarin(gun);
        marinA.Name = "Super Marin B";
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
}
```
위 두 코드를 보면 거의 중복임을 알 수있다.
그럼 함수로 만들어보자.

```cs
private AttackableUnit CreateMarin(string marinName)
{
    IWeapon gun = new Gun();

    Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
    var userInput = Console.ReadLine();
    AttackableUnit marin = null;

    switch (userInput)
    {
        case "1":
            marin = new SmartMarin(gun);
            marin.Name = "Smart " + marinName;
            break;
        case "2":
            marin = new SuperMarin(gun);
            marin.Name = "Super" + marinName;
            break;
        default:
            throw new NotImplementedException("Wrong input entered");
    }

    return marin;
}
```

그러면 run 함수는 아래와 같이 짧아졌다.
```cs
public void Run()
{
    AttackableUnit marinA = CreateMarin("Marin A");
    AttackableUnit marinB = CreateMarin("Marin B");

    while (marinA.HP > 0 && marinB.HP > 0)
    {
        marinA.Attack(marinB);
        Console.WriteLine();

        marinB.Attack(marinA);
        Console.WriteLine();
    }

    var winner = marinA.HP > 0 ? marinA.Name : marinB.Name;

    Console.WriteLine($"The winner is {winner}");
}
```
함수로 고쳤고, 코드 중복도 없어보인다. 문제가 없는것일까?
1. 이 함수가 여기에 있는게 맞을까?
2. 나중에 FlyingMarin를 추가하기 위해, 이 클래스를 변경하는게 맞을까?

먼저 1번을 생각해보자.
만약 추후에 다른 클래스에서도 유저 입력에 따라 마린을 생성한다고 가정해보자.
그곳에 또 CreateMarin 함수를 만들것인가? (함수 중복)

그럼 2번을 생각해보자.
만약 FlyingMarin이 추가되면, 여기에 있는 CreatMarin 함수와, 다른곳에 새로 생긴 CreatMarin 두곳에 다
아래와 같은 코드를 추가해야된다. (CreatMarin 함수가 존재하는곳 다 찾아서 수정해야함)
```cs
case "3":
    marin = new FlyingMarin(gun);
    marin.Name = "Flying " + marinName;
    break;
```
이럴때 사용하는게 Factory pattern이다.
**객체를 생성하는 부분을 한곳에 모아서 관리를 용이하게 하기 위해 사용한다.**
아래와 같이 Factory 클래스를 하나 생성하면
```cs
public class MarinFactory
{
    public static AttackableUnit CreateMarin(string marinName)
    {
        IWeapon gun = new Gun();

        Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
        var userInput = Console.ReadLine();
        AttackableUnit marin = null;

        switch (userInput)
        {
            case "1":
                marin = new SmartMarin(gun);
                marin.Name = "Smart " + marinName;
                break;
            case "2":
                marin = new SuperMarin(gun);
                marin.Name = "Flying " + marinName;
                break;
            default:
                throw new NotImplementedException("Wrong input entered");
        }

        return marin;
    }
}
```
1번 문제가 해결된다. 언제 어디서든 MarinFactory.CreateMarin 함수를 호출하면 간단하게 Marin을 생성할수있다.
```cs
AttackableUnit marinA = MarinFactory.CreateMarin("Marin A");
AttackableUnit marinB = MarinFactory.CreateMarin("Marin B");
```
또 한 2번문제 FlyingMarin을 추가해야 할 경우 MarinFactory.CreatMarin 함수 한군데만 수정하면 된다.
```cs
switch (userInput)
{
    case "1":
        marin = new SmartMarin(gun);
        marin.Name = "Smart " + marinName;
        break;
    case "2":
        marin = new SuperMarin(gun);
        marin.Name = "Super " + marinName;
        break;
    case "3":
        marin = new FlyingMarin(gun);
        marin.Name = "Flying " + marinName;
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
}
```
지금은 함수 내부에서 유저의 입력을 받지만 보통 유저의 입력은 밖에서 받고
CreatMarin 함수 호출할때 인자로 인풋을 보내는게 일반적이다.
```cs
Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
var userInput = Console.ReadLine();
AttackableUnit marinA = MarinFactory.CreateMarin(userInput, "Marin A");
```
그리고 여기서는 string 으로 case문을 작성했는데, string보다는 enum을 사용하면 실수를 방지할 수 있다.
예를들어 4를 입력받으면 InvisibleMarin을 만들려고 하다가 실수로 4가 아닌 44을 하드코딩했다고 가정하자
```cs
case "44":
    marin = new InvisibleMarin(gun);
    marin.Name = "Invisible " + marinName;
    break;
```
추후에 유저가 4를 입력하면 런타임 에러 NotImplementedException("Wrong input entered"); 가 발생할것이다.
이런 실수를 방지하기 위해 enum을 사용하는게 더 효율적이다.
```cs
public enum MarinType
{
	SmartMarin = 1,
	SuperMarin = 2,
	FlyingMarin = 3,
	InvisibleMarin = 4,
}
```
그러면 스위치 문도
```cs
switch (userInput) //물론 userInput MarinType enum type이여야 한다.
{
    case MarinType.SmartMarin:
        marin = new SmartMarin(gun);
        marin.Name = "Smart " + marinName;
        break;
    case MarinType.SuperMarin:
        marin = new SuperMarin(gun);
        marin.Name = "Super " + marinName;
        break;
    case MarinType.FlyingMarin:
        marin = new FlyingMarin(gun);
        marin.Name = "Flying " + marinName;
        break;
    case MarinType.InvisibleMarin:
        marin = new InvisibleMarin(gun);
        marin.Name = "Flying " + marinName;
        break;
    default:
        throw new NotImplementedException("Wrong input entered");
}
```
그외에도 Reflection을 사용하면 case도 줄일수 있을듯하다...(물론 오버킬이긴 하다...)