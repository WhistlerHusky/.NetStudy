using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

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
