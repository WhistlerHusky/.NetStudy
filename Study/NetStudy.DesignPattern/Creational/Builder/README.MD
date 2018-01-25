# Builder pattern

## 1. Builder, 말 그대로 조립하는 패턴
Factory method pattern 이 제품을 "찍어" 내는 패턴이라고 한다면,
```csharp
MarineFactory koreanMarineFactory = new KoreanMarineFactory();
var koreanMarine1 = koreanMarineFactory.CreateNewMarine("1");
Console.WriteLine(koreanMarine1.GetType().Name);
```

Builder pattern 은 제품을 조립하는 패턴이라고 보면된다.
```csharp
//Director 이용
MarineDirector marinDirector = new MarineDirector();
MarinBuilder marinBuilder = new KoreanMarinBuilder();

marinDirector.CreateMarine(marinBuilder); //여기 CreateMarine 안이 Factory method와 다르다
var marin = marinBuilder.Marin;
Console.WriteLine();
```

Director CreateMarine 는 아래와 같이 정의되어있다.
```csharp
public void CreateMarine(MarinBuilder marainBuilder)
{
    marainBuilder
        .SetWeapon() //이렇게 스텝으로 하나씩 하나씩 빌드한다.
        .SetBulletProofVest();
}
```

만약 Director 없이 사용한다면, 아래와 같이 사용가능하고
```csharp
marinBuilder = new KoreanMarinBuilder();
marinBuilder.SetWeapon().SetBulletProofVest();
marin = marinBuilder.Marin;
```
SetWeapon(인자)를 주는 방법도 가능하다.

