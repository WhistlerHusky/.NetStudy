using System;

namespace NetStudy.InDepth.Variant
{
    /// <summary>
    /// Animal은 이름 길이로 왕을 뽑는다.
    /// </summary>
    public class FindKingAnimal: IContravariance<Animal> 
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

        IComparable<string> comparable = new ObjectComparable<object>();
    }

    public class ObjectComparable<T> : IComparable<T>
    {
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is ObjectComparable<T>)) throw new ArgumentException($"Object must be of type {nameof(ObjectComparable<T>)}");
            return CompareTo((ObjectComparable<T>) obj);
        }

        public int CompareTo(T other)
        {
            return 0;
        }
    }

    /// <summary>
    /// Lion은 Power로 뽑느다.
    /// </summary>
    public class FindKingLion : IContravariance<Lion>
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