using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Iterator
{
    public interface Iterator
    {
        Unit First();
        Unit Next();
        bool IsDone();
        Unit CurrentItem();
    }
}
