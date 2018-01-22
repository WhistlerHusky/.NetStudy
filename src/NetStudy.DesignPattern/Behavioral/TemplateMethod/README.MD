# Template Method pattern
> 여러 클래스들이 동일하게 호출하는 함수 혹은 알고리즘을 상위 클래스에서 구현하고, 그 함수 혹은 알고리즘의 상세한(달라지는)부분을 각각의 하위클래스에서 구현하는 패턴

##1. Builder vs Template Method
Build pattern은 생성과 관련된 패턴으로 객체를 생성하는 것을 하위 클래스에 위임하는 것으로 호출순서는 얼마든지 바꿀수있지만, Template Method는 행동 패턴으로 공통된 행동은 상위 클래스, 각각의 행동을 하위 클래스에 구현하며 상위 클래스에서 구현된 함수 호출순서를 바꿀수가 없다.

스타를 하다보면 각 종족별로 초반 빌드라는게 존재한다. 테란의 경우 8배럭스 혹은, 8스플 12 배럭 같은것이 있다.

두 빌드다 동일하게 초반에 scv를 4마리를 생상한 이후에 패턴이 갈린다.

이렇게 공통되는 사항을 상위(Terranbuild)클래스에 정의하고
```csharp
public abstract class TerranBuild
{
	//여기에 공통사항은 그냥 함수로 구현
    private void CreateWorkers()
    private void IncreaseAvailableUnitCount()

    //다르게 구현되는건 abstract선언으로 하위클래스에서 재 정의하게 강제!
    public abstract void CreateBarracks();
}
```
그럼 정해진 빌드가 어떻게 호출되는지 살펴보자

```csharp
public void PrepareWar()
{
    Console.WriteLine($"Current unit {_currentUnitCount}/{_currentSupplyBlock}");

	//일단 무조건 마린4마리 생성
	CreateWorkers();

    //abstract 임으로 하위 클래스에 의해 각각 구현이 달라짐.
    CreateBarracks();

	//여기서 무조건 서플1개는 짓게됨.
    IncreaseAvailableUnitCount();
}
```

그럼 8서플라이 빌들를 보자
```csharp
public class Terran8SCVThenSuppliesBuild : TerranBuild
{
	//8서플 빌드는 배럭스를 짓지않고 8번째 scv이후 서플라이를 짓는것임으로 배럭스 짓는 함수를 그냥 아무것도 하지않고 넘기면된다.
    public override void CreateBarracks()
    {
        //배럭스 짓지않고 패스
    }
}
```
결과는 아래와 같다.
```
Current unit 4/10
SCV is created
Current Unit Count = 5 / 10

SCV is created
Current Unit Count = 6 / 10

SCV is created
Current Unit Count = 7 / 10

SCV is created
Current Unit Count = 8 / 10

A supply depot is just created
Current Unit Count = 8 / 18
```

반면 8배럭스 빌드를 보자.
```csharp
public class Terran8SCVThenBarracksBuild : TerranBuild
{
	//여기서는 배럭스를 짓는다.
    public override void CreateBarracks()
    {
        Console.WriteLine("A barracks is just created");
        Console.WriteLine($"Current Unit Count = {_currentUnitCount} / {_currentSupplyBlock}");
        Console.WriteLine();
    }
}
```
```
Current unit 4/10
SCV is created
Current Unit Count = 5 / 10

SCV is created
Current Unit Count = 6 / 10

SCV is created
Current Unit Count = 7 / 10

SCV is created
Current Unit Count = 8 / 10

A barracks is just created //이부분이 추가되었다.
Current Unit Count = 8 / 10

A supply depot is just created
Current Unit Count = 8 / 18
```