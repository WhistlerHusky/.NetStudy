using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Visitor
{
    public interface IVisitor
    {
        void Visit(Unit unit);
    }
}