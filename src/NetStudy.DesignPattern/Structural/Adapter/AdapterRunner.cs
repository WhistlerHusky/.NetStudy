using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Structural.Decorator;

namespace NetSutdy.DesignPattern.Structural.Adapter
{
    public class AdapterRunner : IRunner
    {
        public void Run()
        {
            SmartMarine sm = new SmartMarine();
            sm.SetWeapon(new LaserGunAdapter(new LaserGun2()));

            StupidMarine sp = new StupidMarine();

            sm.Fire(sp);
        }
    }   
}
