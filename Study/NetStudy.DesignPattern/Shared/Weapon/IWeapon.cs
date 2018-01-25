using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public interface IWeapon
    {
        int Damage { get; }
        void Fire(Unit unit);
    }
}
