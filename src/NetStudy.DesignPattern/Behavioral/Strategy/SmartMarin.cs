using System;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class SmartMarin : AttackableUnit
    {
        public SmartMarin(IWeapon weapon)
        {
            _hp = 40;

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
