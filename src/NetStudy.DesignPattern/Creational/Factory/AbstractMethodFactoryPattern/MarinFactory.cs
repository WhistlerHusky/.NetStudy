using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern
{
    public abstract class MarineFactory
    {
        public AttackableUnit CreateNewMarine(string marineType)
        {
            var marine = CreateMarine(marineType);
            marine.SetInitialHP();
            return marine;
        }

        public abstract AttackableUnit CreateMarine(string marineType);
    }
}
