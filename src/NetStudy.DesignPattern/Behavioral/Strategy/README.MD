<h1>Strategy pattern</h1>

디자인 패턴을 공부하면서 제일 처음 접했던 디자인 패턴.

구현보다는 구성! 이라는 말이 무슨뜻인지 설명해주는 패턴.

IWeapon 이라는 인터페이스가 있다고 가정하자.
```cs
public interface IWeapon
{
    void Fire(Unit unit);
}
```

멍청한 마린은 IWeapon을 구현을 하였기 때문에,
```cs
public class StupidMarine : Unit, IWeapon
```
추후에 바꿔주려면 StupidMarine 클래스 자체를 수정해야 한다.
```cs
public class StupidMarine : Unit, IWeapon
{
            .
            .
    public void Fire(Unit unit)
    {
      //직접 내부 구현을 수정해야한다.
      int initDamage = 5;

      unit.GotDamage(initDamage);
    }
}
```
반면, 똑똑한 마린은 IWeapon을 구성으로 가지고 있기 때문에,
```cs
public class AttackableUnit : Unit
{
    private IWeapon _weapon;
           .
           .
}
public class SmartMarine : AttackableUnit
{
}
```
이렇게 무기를 만들어서
```cs
public class Gun : IWeapon
{
  public void Fire(Unit unit)
  {
    int initDamage = 5;

    unit.GotDamage(initDamage);
  }
}
```
생성자나, 프라퍼티 혹은 메서드를 통해 교체해주면 된다.
```cs
IWeapon gun = new Gun();
SmartMarine smartMarine = new SmartMarine(gun);
```
추후 업데이트로 마린이 다른무기도 사용가능하게 될 경우, 해당 마린 클래스를 수정하지않고, IWeapon을 구현하는 무기를 만들어서
```cs
public class LaserGun : IWeapon
{
    public void Fire(Unit unit)
    {
      int initDamage = 8;

      unit.GotDamage(initDamage);
    }
}
```
이렇게 무기만 바꿔주면 된다.
```cs
smartMarine.ChangeWeapon(new LaserGun());
```

무기 바꾸는 메소드
```cs
public void ChangeWeapon(IWeapon weapon)
{
    _weapon = weapon;
}
```
