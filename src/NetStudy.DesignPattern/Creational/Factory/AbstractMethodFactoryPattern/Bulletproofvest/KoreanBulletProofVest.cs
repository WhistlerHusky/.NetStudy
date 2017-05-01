using System.Diagnostics;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest
{
    public class KoreanBulletProofVest : IBulletProofVest
    {
        public int ReduceDamage(int damage)
        {
            return damage / 2;
        }
    }
}
