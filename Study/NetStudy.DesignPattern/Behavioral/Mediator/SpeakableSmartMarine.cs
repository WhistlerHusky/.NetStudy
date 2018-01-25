using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Behavioral.Mediator
{
    public class SpeakableSmartMarine : SpeakableUnit
    {
        public SpeakableSmartMarine() : base()
        {
            _currentHp = 40;
            MaxHp = 50;
        }
        public SpeakableSmartMarine(string name) 
            : this()
        {
            Name = name;
        }
        public SpeakableSmartMarine(IWeapon weapon)
            : this()
        {
            _weapon = weapon;
        }
    }
}
