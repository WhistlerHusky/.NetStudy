namespace NetSutdy.DesignPattern.Creational.Builder
{
    public class MarineDirector
    {
        public void CreateMarine(MarinBuilder marainBuilder)
        {
            marainBuilder
                .SetWeapon()
                .SetBulletProofVest();
        }
    }
}
