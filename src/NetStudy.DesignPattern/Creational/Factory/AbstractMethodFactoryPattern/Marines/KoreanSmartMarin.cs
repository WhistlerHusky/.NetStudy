using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public class KoreanSmartMarine : AttackableUnit
    {
        IMarineSettingFactory _marineSettingFactory;
        public KoreanSmartMarine(IMarineSettingFactory marineSettingFactory)
        {
            _marineSettingFactory = marineSettingFactory;
        }
        public override void GetReadyToFight()
        {
            _weapon = _marineSettingFactory.GetWeapon();
            _bulletProofVest = _marineSettingFactory.GetBulletProofVest();
        }

        /// <summary>
        /// 이부분이 Strategy 패턴의 핵심이다.
        /// </summary>
        /// <param name="weapon"></param>
        public void ChangeWeapon(IWeapon weapon)
        {
            Console.WriteLine($"{Name} changes weapon from {_weapon.GetType().Name} -> {weapon.GetType().Name}");
            _weapon = weapon;
        }

    }
}
