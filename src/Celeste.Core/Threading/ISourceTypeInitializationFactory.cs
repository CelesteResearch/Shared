namespace Celeste.Core.Threading
{
    public interface ISourceTypeInitializationFactory<T>
    {
        T Allocate();
        void Initialize(T instance);
    }
}
