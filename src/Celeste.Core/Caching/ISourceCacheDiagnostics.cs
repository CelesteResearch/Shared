namespace Celeste.Core.Caching
{
    public interface ISourceCacheDiagnostics
    {
        void CachedValue<TKey, TValue>(string name, TKey key, TValue value, int count);
    }
}
