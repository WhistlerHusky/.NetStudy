# NSubstitute
Moq을 사용하려고 했지만, NSubstitute 코드가 더 가독성이 좋아보임.

```csharp
//NSubstitute code
var testMarin = Substitute.For<AttackableUnit>();
var testWeapon = Substitute.For<IWeapon>();
testWeapon.Damage.Returns(10);
testMarin.SetWeapon(testWeapon);
testFirebat.CurrentHp.ShouldBe(25); //shouldy 는 거들뿐
```

