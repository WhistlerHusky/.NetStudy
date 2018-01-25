using System;

namespace CastleWindsor
{
    public interface ITypedFactoryFacility : IDisposable
    {
        T Create<T>();
        void Release(object service);
    }
}
