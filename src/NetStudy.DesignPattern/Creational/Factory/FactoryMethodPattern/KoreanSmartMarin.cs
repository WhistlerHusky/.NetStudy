using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanSmartMarine : AttackableUnit
    {
        public KoreanSmartMarine() : base()
        {
            _hp = 40;
        }

        public KoreanSmartMarine(IWeapon weapon) : this()
        {
            _weapon = weapon;
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
