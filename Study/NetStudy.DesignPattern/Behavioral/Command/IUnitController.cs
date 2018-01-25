using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public interface IUnitController
    {
        void CreateUnit(Unit unit, int x, int y);
        void DeleteUnit(Unit unit, int x, int y);
    }
}