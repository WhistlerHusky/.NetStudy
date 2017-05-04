using System;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class SmartMarine : AttackableUnit
    {
        public SmartMarine() : base()
        {
        }
        public SmartMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}
