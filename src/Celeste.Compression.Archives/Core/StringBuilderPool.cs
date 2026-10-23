using System.Collections.Concurrent;
using System.Text;

namespace ICSharpCode.SharpZipLib.Core
{
    internal class StringBuilderPool
    {
        public static StringBuilderPool Instance { get; } = new();
        private readonly ConcurrentQueue<StringBuilder> pool = new();

        public StringBuilder Rent()
        {
            return pool.TryDequeue(out var builder) ? builder : new();
        }

        public void Return(StringBuilder builder)
        {
            builder.Clear();
            pool.Enqueue(builder);
        }
    }
}
