using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.State
{
    public interface IState
    {
        AttackableUnit Unit { get; set; }
        void Attack(Unit unit);
        void GotDamaged(int damage);
    }
}
