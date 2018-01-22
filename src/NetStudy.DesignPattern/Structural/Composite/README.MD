# Composite pattern
객체와 객체의 그룹을 구분없이 하나의 인터페이스로 다룰 수 있게 한다.
대부분의 책에서는 예제를 tree 폴더 구조 예를 가지고 설명한다.
Leaf(파일), Composite(폴더)로 폴더안에는 Leaf 혹은 Composite이 들어갈수 있다.

여기서는 스타크래프트 유닛 부대지정을 가지고 이용했다.
처음에 Dropship을 이용하려고 했지만, 생각해보니 드랍쉽은 Composite이 아니다.

```csharp
 public class UnitSelectors : AttackableUnit
 {
     readonly IList<AttackableUnit> _attackableUnits = new List<AttackableUnit>();

     public override void Attack(Unit unit)
     {
         Console.WriteLine($"Group Attack started");

         foreach (var attackAbleUnit in _attackableUnits)
         {
             attackAbleUnit.Attack(unit);
             Console.WriteLine();
         }

         Console.WriteLine($"Group Attack ended");
     }

     public void AddAttackAbleUnit(AttackableUnit unit)
     {
         _attackableUnits.Add(unit);
     }
     public void RemoveAttackAbleUnit(AttackableUnit unit)
     {
         _attackableUnits.Remove(unit);
     }
 }   
```
