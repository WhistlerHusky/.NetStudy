namespace NetSutdy.DesignPattern.Shared.Bulletproofvest
{
    public class KoreanBulletProofVest : IBulletProofVest
    {
        public int ReduceDamage(int damage)
        {
            return damage / 2;
        }
    }
}
