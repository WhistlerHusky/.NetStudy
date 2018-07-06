using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NSubstitute_Test
{
    public class NSubstituteRunner_Test 
    {
        [Fact]
        public void ShouldWorkWithNSubstite()
        {
            var testMarin = Substitute.For<AttackableUnit>();
            var testWeapon = Substitute.For<IWeapon>();
            var testFirebat = Substitute.For<AttackableUnit>();
            testFirebat.CurrentHp = 35;
            testWeapon.Damage.Returns(10);
            testMarin.SetWeapon(testWeapon);

            testMarin.When(x => x.Attack(testFirebat)).Do(x => testMarin.Fire(testFirebat));
            testMarin.When(x => x.Fire(testFirebat)).Do(x => testWeapon.Fire(testFirebat));
            testWeapon.When(x => x.Fire(testFirebat)).Do(x => testFirebat.CurrentHp -= 10);

            testMarin.Attack(testFirebat);
            testFirebat.CurrentHp.ShouldBe(25);
        }
    }
}
