using System.Diagnostics;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest
{
    public class UsaBulletProofVest : IBulletProofVest
    {
        public int ReduceDamage(int damage)
        {
            return damage / 3;
        }
    }
}
