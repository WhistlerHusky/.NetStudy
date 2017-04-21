namespace NetStudy.DifficultSubject.Variant
{
    /// <summary>
    /// Covariant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICovarianct<out T> // out, 즉 return type을 꺼내(out)으로만 사용함
    {
        T GetKing();
    }

    /// <summary>
    /// 
    /// </summary>
    public class CovariantAnimal : ICovarianct<Animal>
    {
        public Animal GetKing()
        {
            return new Animal("Animal", 1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CovariantLion : ICovarianct<Lion>
    {
        public Lion GetKing()
        {
            return new Lion("Lion", 99);
        }
    }
}