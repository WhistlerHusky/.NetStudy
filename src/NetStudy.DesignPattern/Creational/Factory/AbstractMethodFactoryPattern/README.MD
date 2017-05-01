# Abstract Factory Pattern

Abstract Factory Pattern은 일련의 연관성이 있는 여러개의 객체군을 각각의 Concreate Factory 클래스를 통해 동일한 객체군을 만드는 패턴이다.
Factory Method와 자주 헷갈리는데, 이는 Factory Method에도 아래와 같이 abstract 클래스가 존재해서 그런듯하다.
```cs
public abstract class MarineFactory
{
    public abstract AttackableUnit CreateMarine(string marineType);
}
```

Abstract Factory는 패턴을 생성해야 할 **객체군의 공통점**에 촛점을 맞춘다 (2번 부터가 핵심)
1. 마린 생성
2. 마린의 자국산 무기 장착
3. 마린의 자국산 방탄조끼 장착
4. 마린의 자국산 헬멧, 전투화 등등

한국 마린을 생성할 때 한국산을 착용하게끔 일련의 연광성있는(국산) 여러개의 객체군(무기, 방탄, 헬멧, 전투화)을 Concreate Factory 클래스를 통해 생성

먼저 국산 마린의 무기와 방탄조끼 세팅을 담당하는 클래스르
```cs
public class KoreanMarineSettingFactory : IMarineSettingFactory
{
    public IWeapon GetWeapon()
    {
        return new DoubleGun();
    }

    public IBulletProofVest GetBulletProofVest()
    {
        return new KoreanBulletProofVest();
    }
}
```
위 클래스 객체를 아래와 같이 KoreanMarineFactory에서 국산 마린 생성자 인자로 넘겨주면
```cs
public class KoreanMarineFactory : MarineFactory
{
    public override AttackableUnit CreateMarine(string marineType)
    {
        AttackableUnit marine = null;

        IMarineSettingFactory marineSettingFactory = new KoreanMarineSettingFactory();

        switch (marineType)
        {
            case "1":
                marine = new KoreanFlyingMarine(marineSettingFactory);
```
국산 마린이 가져오는 방탄조끼와 무기는 국산이된다.
```cs
public class KoreanFlyingMarine : AttackableUnit
{
    private IMarineSettingFactory _marineSettingFactory;

    public KoreanFlyingMarine(IMarineSettingFactory marineSettingFactory)
    {
        _marineSettingFactory = marineSettingFactory;
    }

    public override void GetReadyToFight()
    {
        _weapon = _marineSettingFactory.GetWeapon();
        _bulletProofVest = _marineSettingFactory.GetBulletProofVest();
    }
```

Factory Method 패턴은 생성 이후 **해야 할 일의 공통점을 정의**하는데 촛점을 맞춘다. (1번이 핵심)
1. 마린생성
2. 장비 장착 (어떤 마린이 생성됐는지 알수 없지만 일단 무기와 방탄조끼를 장착한다.)
3. 전쟁터 출발
어떤 마린이(1번) 이 생성되느냐에 따라 2번 장비 장착을 한다. 즉 1번의 객체 의해 2, 3번이 달라짐.

가끔 코딩하다보면 생성자에서 특정 작업을 수행할수 없고, 생성이 완료된 이후에 작업을 해줘야 하는 경우가 있는데,
이럴때 Factory Method를 이용하면, 객체 생성이후 작업해야되는 코드를 한곳에서 작성할 수 있어, 여러군데서 코딩하다가 까먹는 실수를 하지않아 유지 보수가 용의해짐.
