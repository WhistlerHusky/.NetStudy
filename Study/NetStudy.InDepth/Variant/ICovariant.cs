namespace NetStudy.InDepth.Variant
{
    /// <summary>
    /// Covariant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICovariance<out T> // out, 즉 return type을 꺼내(out)으로만 사용함
    {
        T GetKing();
    }
}