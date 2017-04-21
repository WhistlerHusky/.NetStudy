using System;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class SmartMarin : Unit
    {
        private IWeapon _weapon;

        public SmartMarin(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }

        public void Attach(Unit unit)
        {
            //hp가 0이하로 내려가면 죽은거임.
            if (_hp <= 0)
            {
                return;
            }

            Console.WriteLine($"{Name} attacks {unit.Name}");
            _weapon.Fire(unit);
        }

        /// <summary>
        /// 이부분이 Strategy 패턴의 핵심이다.
        /// </summary>
        /// <param name="weapon"></param>
        public void ChangeWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }
    }
}
