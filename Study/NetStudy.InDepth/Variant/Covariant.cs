namespace NetStudy.InDepth.Variant
{
 
    /// <summary>
    /// 
    /// </summary>
    public class CovariantAnimal : ICovariance<Animal>
    {
        public Animal GetKing()
        {
            return new Animal("Animal", 1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CovariantLion : ICovariance<Lion>
    {
        public Lion GetKing()
        {
            return new Lion("Lion", 99);
        }
    }
}