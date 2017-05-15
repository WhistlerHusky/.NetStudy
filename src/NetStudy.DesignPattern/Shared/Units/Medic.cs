using NetSutdy.DesignPattern.Shared.Weapon;
using System;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class Medic : Unit
    {
        public Medic()
        {
            _hp = 50;
        }

        public Medic(string name) 
            : this()
        {
            Name = name;
        }
    }
}
