using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Memento
{
    public static class MementoExtensionHelper
    {
        public static Memento CreateMemento(this Unit unit)
        {
            return new Memento{ CurrentHp =  unit.CurrentHp, MaxHp = unit.MaxHp, Name = unit.Name};
        }

        public static void RestoreMemento(this Unit unit, Memento memento)
        {
            unit.Name = memento.Name;
            unit.CurrentHp = memento.CurrentHp;
            unit.MaxHp = memento.MaxHp;
        }
    }
}
