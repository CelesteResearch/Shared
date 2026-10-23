using System;

namespace Celeste.Core.Text
{
    public static class SourceSpanLineExtensions
    {
        public static SourceSpanLineEnumerator EnumerateLines(this ReadOnlySpan<char> buffer) => new(buffer);
    }
}
