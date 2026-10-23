// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Celeste.Core.Text
{
    public ref struct SourceSpanLineEnumerator
    {
        private ReadOnlySpan<char> remaining;
        private ReadOnlySpan<char> current;
        private bool isEnumeratorActive;

        internal SourceSpanLineEnumerator(ReadOnlySpan<char> buffer)
        {
            remaining = buffer;
            current = default;
            isEnumeratorActive = true;
        }

        public ReadOnlySpan<char> Current => current;
        public SourceSpanLineEnumerator GetEnumerator() => this;

        public bool MoveNext()
        {
            if (!isEnumeratorActive) return false;
            ReadOnlySpan<char> rest = remaining;
            int index = rest.IndexOfAny("\r\f\u0085\u2028\u2029\n".AsSpan());
            if ((uint)index < (uint)rest.Length)
            {
                int stride = 1;
                if (rest[index] == '\r' && (uint)(index + 1) < (uint)rest.Length && rest[index + 1] == '\n')
                    stride = 2;
                current = rest.Slice(0, index);
                remaining = rest.Slice(index + stride);
            }
            else
            {
                current = rest;
                remaining = default;
                isEnumeratorActive = false;
            }

            return true;
        }
    }
}
