using System;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class Unit
    {
        protected int _currentHp;

        public string Name { get; set; }

        public int MaxHp { get; set; }

        public int CurrentHp
        {
            get => _currentHp;

            set
            {
                _currentHp = value;
                if (_currentHp <= 0)
                {
                    Console.WriteLine($"{Name} died");
                }
            }
        }

        public virtual void GotDamage(int damage)
        {
            if (CurrentHp <= 0)
            {
                return;
            }
            Console.WriteLine($"{Name} got attacked! {CurrentHp} -> {((CurrentHp - damage) > 0 ? (CurrentHp - damage): 0)}");
            CurrentHp -= damage;
        }
    }
}
