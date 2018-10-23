using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Iterator
{
    public interface ITerator
    {
        Unit First();
        Unit Next();
        bool IsDone();
        Unit CurrentItem();
    }
}
