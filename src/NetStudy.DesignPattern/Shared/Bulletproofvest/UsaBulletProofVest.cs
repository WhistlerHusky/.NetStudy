namespace NetSutdy.DesignPattern.Shared.Bulletproofvest
{
    public class UsaBulletProofVest : IBulletProofVest
    {
        public int ReduceDamage(int damage)
        {
            return damage / 3;
        }
    }
}
