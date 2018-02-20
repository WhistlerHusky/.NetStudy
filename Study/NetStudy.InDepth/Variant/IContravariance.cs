namespace NetStudy.InDepth.Variant
{
    /// <summary>
    /// Contravariant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContravariance<in T> // in, 즉 parameter type으로 (in)넣을때만 사용함
    {
        string GetKing(T first, T second);
    }
}