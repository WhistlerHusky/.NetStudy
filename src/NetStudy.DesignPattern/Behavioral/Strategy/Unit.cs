using System;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class Unit
    {
        public string Name { get; set; }

        protected int _hp;
        public int HP
        {
            get => _hp;

            set
            {
                _hp = value;
                if (_hp <= 0)
                {
                    Console.WriteLine($"{Name} died");
                }
            }
        }

        public void GotDamage(int damage)
        {
            Console.WriteLine($"{Name} got attacked! {HP} -> {HP - damage}");
            HP -= damage;
        }
    }
}
