namespace NetSutdy.DesignPattern.Structural.Facade
{
    public static class UnitHelper
    {
        public static int GetSupplyNumber(UnitType unitType)
        {
            return 1;
        }

        public static int GetRequiredMinerals(UnitType unitType)
        {
            return 50;
        }

        public static int GetRequiredGas(UnitType unitType)
        {
            int requiredGas = 0;

            switch (unitType)
            {
                case UnitType.Marine:
                    break;
                case UnitType.Firebat:
                    requiredGas = 25;
                    break;
                case UnitType.Medic:
                    requiredGas = 50;
                    break;
            }

            return requiredGas;
        }
    }
}