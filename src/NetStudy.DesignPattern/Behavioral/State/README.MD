# State pattern
>상태변화를 가지는 주요 객체를 다룰 때 유용하게 적용가능한 패턴으로 객체의 내부 상태가 바뀜에 따라서 객체의 행동을 바꿀 수 있다.

먼저 상태를 정의하고.
```cs
public interface IState
{
    AttackableUnit Unit { get; set; }
    void Attack(Unit unit);
    void GotDamaged(int damage);
}
```
마린이 가질수 있는 상태를 3가지로 나눴다.

```cs
    public class NormalStateMarine : IState
    {
        public void Attack(Unit unit)
        {
            Unit.Fire(unit);
        }
        public void GotDamaged(int damage)
        {
            Unit.CurrentHp -= damage;
        }
    }
    public class FrozenStateMarine : IState
    {
        public void Attack(Unit target)
        {
            //공격안됨
            Console.WriteLine($"Frozen {Unit.Name} cannot attack {target.Name}.");
        }
        public void GotDamaged(int damage)
        {
            //데미지를 입지않음
            Console.WriteLine($"Frozen {Unit.Name} cannot get damanged");
        }
    }
    public class StimpackStateMarine : IState
    {
        public void Attack(Unit unit)
        {
            //두번공격
            Unit.Fire(unit);
            Unit.Fire(unit);
        }
        public void GotDamaged(int damage)
        {
            Unit.CurrentHp -= damage;
        }
    }
```

실행하는 코드
```cs
StateMarine marine1 = new StateMarine();
marine1.Name = "Marine 1";
StateMarine marine2 = new StateMarine();
marine2.Name = "Marine 2";

for (int i = 0; i < 7; i++)
{
	//먼저 marine2가 7번 맞음
    marine1.Attack(marine2); 
}
```
```
Marine 2 got attacked! 40 -> 35
Marine 2 got attacked! 35 -> 30
Marine 2 got attacked! 30 -> 25
Marine 2 got attacked! 25 -> 20
Marine 2 got attacked! 20 -> 15
Marine 2 got attacked! 15 -> 10
Marine 2 got attacked! 10 -> 5
```

```cs
//현재 HP 5남음
Console.WriteLine($"Current {marine2.Name} hp = {marine2.CurrentHp}");
```
```
Current Marine 2 hp = 5
```
```cs
//marine2 죽기직전에 arbiter에게 얼음
Arbiter arbiter = new Arbiter();
arbiter.StasisField(marine2);
```
```CS
for (int i = 0; i < 7; i++)
{
	//얼어있는 상태에서는 피해를 입지않음
    marine1.Attack(marine2);
}
```
```
Frozen Marine 2 cannot get damanged
Frozen Marine 2 cannot get damanged
Frozen Marine 2 cannot get damanged
Frozen Marine 2 cannot get damanged
Frozen Marine 2 cannot get damanged
Frozen Marine 2 cannot get damanged
Frozen Marine 2 cannot get damanged
```
```cs
//마린2 스팀팩 사용하고 반격
marine2.StateChanged(MarineState.Stimpack);

//4번 공격 했지만 스팀 상태로 8번 공격이 나감.
marine2.Attack(marine1);
marine2.Attack(marine1);
marine2.Attack(marine1);
marine2.Attack(marine1);
marine2.Attack(marine1);
```
```
Marine 1 got attacked! 40 -> 35
Marine 1 got attacked! 35 -> 30
Marine 1 got attacked! 30 -> 25
Marine 1 got attacked! 25 -> 20
Marine 1 got attacked! 20 -> 15
Marine 1 got attacked! 15 -> 10
Marine 1 got attacked! 10 -> 5
Marine 1 got attacked! 5 -> 0
Marine 1 died
Press any key to continue . . .
```