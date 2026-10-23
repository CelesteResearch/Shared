// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Celeste.Core.Text
{
    public ref struct SourceSpanLineEnumerator
    {
        private ReadOnlySpan<char> _remaining;

        private ReadOnlySpan<char> _current;
        private bool _isEnumeratorActive;

        internal SourceSpanLineEnumerator(ReadOnlySpan<char> buffer)
        {
            _remaining = buffer;
            _current = default;
            _isEnumeratorActive = true;
        }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public ReadOnlySpan<char> Current => _current;

        public SourceSpanLineEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (!_isEnumeratorActive) return false;
            var rest = _remaining;
            var index = rest.IndexOfAny("\r\f\u0085\u2028\u2029\n".AsSpan());
            if ((uint)index < (uint)rest.Length)
            {
                var stride = 1;
                if (rest[index] == '\r' && (uint)(index + 1) < (uint)rest.Length && rest[index + 1] == '\n')
                    stride = 2;
                _current = rest.Slice(0, index);
                _remaining = rest.Slice(index + stride);
            }
            else
            {
                _current = rest;
                _remaining = default;
                _isEnumeratorActive = false;
            }

            return true;
        }
    }
}
