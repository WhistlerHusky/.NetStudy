using System;
using System.Collections.Generic;
using System.Text;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Builder
{
    public class MarineDirector
    {
        public void CreateMarine(MarinBuilder marainBuilder)
        {
            marainBuilder
                .SetWeapon()
                .SetBulletProofVest();
        }
    }
}
