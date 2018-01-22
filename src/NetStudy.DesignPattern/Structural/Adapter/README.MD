# Adapter pattern
기존에 작성된 코드를 변경하지 않고, 중간에 단계 레이어(어댑터)를 두어 필요에 맞게 변형 하여 사용하는 패턴.

e.g. 현재 IWeapon이라는 인터페이스를 이용하여 무기를 구현했지만, 다른팀에서는
IGun 이라는 인터페이스를 사용하여 무기를 구현했다고 가정해 보자, 이 IGun 인터페이스를 구현하여 만들어진 무기를
사용하고 싶지만, 이미 IWeapon이라는 인터페이스를 이용하고 있는 Marine은 이 IGun 인터페이스 무기를 받을수 없다.

**마린의 무기장착 방법**
```csharp 
//Marine의 SetWeapon은 IWeapon만 받을수있다.
public void SetWeapon(IWeapon weapon)
{
     Console.WriteLine($"{Name} changes weapon from {_weapon.GetType().Name} -> {weapon.GetType().Name}");
     _weapon = weapon;
}
```
**다른팀에서 구현한 IGun**
```csharp
public interface IGun
{
    void Shoot(Unit unit);
}
public class LaserGun2 : IGun
{
    public void Shoot(Unit unit)
    {
        int initDamage = 8;

        unit.GotDamage(initDamage);
        Console.WriteLine($"{GetType().Name} is used." );
    }
}
```

**아래와 같이 사용하고 싶지만 안됨**
```csharp
IWeapon gun = new LaserGun();
Marine.SetWeapon(gun)//작동

IGun gunFromOtherTeam = new GunImple();
Marine.SetWeapon(gunFromOtherTeam)//컴파일 에러, SetWeapon의 파라메터로 IGun을 받을수 없음.


```
하지만 중간에 어댑터를 두면 이야기가 달라진다.

```csharp
public class LaserGunAdapter : IWeapon
{
    private IGun _gun;

    public LaserGunAdapter(IGun gun)
    {
        _gun = gun;
    }

    public void Fire(Unit unit)
    {
        _gun.Shoot(unit);
    }
}

//LaserGunAdapter 라는 클래스를 만들어서, IWeapon을 구현하지만, 실내 내부에서는 그냥 IGun의 객체의 Shoot 함수를 호출만 해주면된다.
```

마린이 IGun 구현체인 LaserGun2를 장착하는 방법.
```csharp
SmartMarine sm = new SmartMarine();
sm.SetWeapon(new LaserGunAdapter(new LaserGun2()));
```