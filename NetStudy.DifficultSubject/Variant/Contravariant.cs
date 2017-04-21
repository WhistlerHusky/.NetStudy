namespace NetStudy.DifficultSubject.Variant
{
    /// <summary>
    /// Contravariant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContravarianct<in T> // in, 즉 parameter type으로 (in)넣을때만 사용함
    {
        string GetKing(T first, T second);
    }


    /// <summary>
    /// Animal은 이름 길이로 왕을 뽑는다.
    /// </summary>
    public class FindKingAnimal: IContravarianct<Animal> 
    {
        /// <summary>
        /// 이름 길이가 긴 동물을 출력
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public string GetKing(Animal first, Animal second)
        {
            return first.Name.Length > second.Name.Length ? first.Name : second.Name;
        }
    }

     /// <summary>
    /// Lion은 Power로 뽑느다.
    /// </summary>
    public class FindKingLion : IContravarianct<Lion>
    {
        /// <summary>
        /// Power가 높은 Lion을 출력.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public string GetKing(Lion first, Lion second)
        {
            return first.Power > second.Power ? first.Name : second.Name;
        }
    }
}