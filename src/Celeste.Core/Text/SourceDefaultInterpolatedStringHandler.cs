using System;
using System.Buffers;
using System.Numerics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;

namespace Celeste.Core.Text
{
    // Formatting state and buffer ownership follow the selected runtime source.
    // Native span formatting is retained for the public netstandard primitive domains.
    public ref struct SourceDefaultInterpolatedStringHandler
    {
        private readonly IFormatProvider _provider;
        private readonly bool _hasCustomFormatter;
        private char[] _arrayToReturnToPool;
        private Span<char> _chars;
        private int _pos;

        internal ReadOnlySpan<char> Text => _chars.Slice(0, _pos);

        public SourceDefaultInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            _provider = null;
            _hasCustomFormatter = false;
            _chars = (_arrayToReturnToPool =
                ArrayPool<char>.Shared.Rent(GetDefaultLength(literalLength, formattedCount)));
            _pos = 0;
        }

        public SourceDefaultInterpolatedStringHandler(int literalLength, int formattedCount, IFormatProvider provider)
        {
            _provider = provider;
            _chars = (_arrayToReturnToPool =
                ArrayPool<char>.Shared.Rent(GetDefaultLength(literalLength, formattedCount)));
            _pos = 0;
            _hasCustomFormatter = provider != null && HasCustomFormatter(provider);
        }

        public SourceDefaultInterpolatedStringHandler(int literalLength, int formattedCount, IFormatProvider provider,
            Span<char> initialBuffer)
        {
            _provider = provider;
            _chars = initialBuffer;
            _arrayToReturnToPool = null;
            _pos = 0;
            _hasCustomFormatter = provider != null && HasCustomFormatter(provider);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int GetDefaultLength(int literalLength, int formattedCount)
            => Math.Max(256, unchecked(literalLength + formattedCount * 11));

        public override string ToString() => new string(Text);

        public string ToStringAndClear()
        {
            string result = new string(Text);
            Clear();
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Clear()
        {
            char[] arrayToReturnToPool = _arrayToReturnToPool;
            this = default(SourceDefaultInterpolatedStringHandler);
            if (arrayToReturnToPool != null)
                ArrayPool<char>.Shared.Return(arrayToReturnToPool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value)
        {
            if (value.AsSpan().TryCopyTo(_chars.Slice(_pos)))
                _pos += value.Length;
            else
                GrowThenCopyString(value);
        }

        public void AppendFormatted(string value)
        {
            if (!_hasCustomFormatter && value != null && value.AsSpan().TryCopyTo(_chars.Slice(_pos)))
                _pos += value.Length;
            else
                AppendFormattedSlow(value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AppendFormattedSlow(string value)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, null);
            }
            else if (value != null)
            {
                EnsureCapacityForAdditionalChars(value.Length);
                value.AsSpan().CopyTo(_chars.Slice(_pos));
                _pos += value.Length;
            }
        }

        // Installed Char.ISpanFormattable.TryFormat, for the source's empty format/provider.
        public void AppendFormatted(char value)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, null);
                return;
            }

            int charsWritten;
            while (!TryFormatChar(value, _chars.Slice(_pos), out charsWritten))
                Grow();
            _pos += charsWritten;
        }

        private static bool TryFormatChar(char value, Span<char> destination, out int charsWritten)
        {
            if (!destination.IsEmpty)
            {
                destination[0] = value;
                charsWritten = 1;
                return true;
            }

            charsWritten = 0;
            return false;
        }

        // Public netstandard2.1 primitive. Its actual runtime Number implementation is
        // an explicit qualification dependency, not claimed to be SDK 8.0.15 here.
        public void AppendFormatted(int value)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, null);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, default(ReadOnlySpan<char>), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(int value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(byte value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(byte value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(sbyte value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(sbyte value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(short value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(short value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(ushort value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(ushort value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(uint value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(uint value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(long value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(long value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(ulong value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(ulong value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(float value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(float value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(double value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(double value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(decimal value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(decimal value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(DateTime value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(DateTime value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(DateTimeOffset value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(DateTimeOffset value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(TimeSpan value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(TimeSpan value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan(), _provider))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(Guid value) => AppendFormatted(value, (string)null);

        public void AppendFormatted(Guid value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            int charsWritten;
            while (!value.TryFormat(_chars.Slice(_pos), out charsWritten, format.AsSpan()))
                Grow();
            _pos += charsWritten;
        }

        public void AppendFormatted(bool value)
        {
            if (_hasCustomFormatter) AppendCustomFormatter(value, null);
            else AppendLiteral(value ? bool.TrueString : bool.FalseString);
        }

        public void AppendFormatted<T>(T value) => AppendFormatted(value, (string)null);

        public void AppendFormatted<T>(T value, string format)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            if (typeof(T) == typeof(int))
            {
                AppendFormatted((int)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(byte))
            {
                AppendFormatted((byte)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(sbyte))
            {
                AppendFormatted((sbyte)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(short))
            {
                AppendFormatted((short)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(ushort))
            {
                AppendFormatted((ushort)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(uint))
            {
                AppendFormatted((uint)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(long))
            {
                AppendFormatted((long)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(ulong))
            {
                AppendFormatted((ulong)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(float))
            {
                AppendFormatted((float)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(double))
            {
                AppendFormatted((double)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(decimal))
            {
                AppendFormatted((decimal)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(DateTime))
            {
                AppendFormatted((DateTime)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(DateTimeOffset))
            {
                AppendFormatted((DateTimeOffset)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(TimeSpan))
            {
                AppendFormatted((TimeSpan)(object)value, format);
                return;
            }

            if (typeof(T) == typeof(Guid))
            {
                AppendFormatted((Guid)(object)value, format);
                return;
            }

            // A value statically typed as object still uses its real primitive span path.
            if (value is int primitive0)
            {
                AppendFormatted(primitive0, format);
                return;
            }

            if (value is byte primitive1)
            {
                AppendFormatted(primitive1, format);
                return;
            }

            if (value is sbyte primitive2)
            {
                AppendFormatted(primitive2, format);
                return;
            }

            if (value is short primitive3)
            {
                AppendFormatted(primitive3, format);
                return;
            }

            if (value is ushort primitive4)
            {
                AppendFormatted(primitive4, format);
                return;
            }

            if (value is uint primitive5)
            {
                AppendFormatted(primitive5, format);
                return;
            }

            if (value is long primitive6)
            {
                AppendFormatted(primitive6, format);
                return;
            }

            if (value is ulong primitive7)
            {
                AppendFormatted(primitive7, format);
                return;
            }

            if (value is float primitive8)
            {
                AppendFormatted(primitive8, format);
                return;
            }

            if (value is double primitive9)
            {
                AppendFormatted(primitive9, format);
                return;
            }

            if (value is decimal primitive10)
            {
                AppendFormatted(primitive10, format);
                return;
            }

            if (value is DateTime primitive11)
            {
                AppendFormatted(primitive11, format);
                return;
            }

            if (value is DateTimeOffset primitive12)
            {
                AppendFormatted(primitive12, format);
                return;
            }

            if (value is TimeSpan primitive13)
            {
                AppendFormatted(primitive13, format);
                return;
            }

            if (value is Guid primitive14)
            {
                AppendFormatted(primitive14, format);
                return;
            }

            if (value is bool boolean)
            {
                AppendFormatted(boolean);
                return;
            }

            if (value is char character)
            {
                AppendFormatted(character);
                return;
            }

            // On the netstandard runtime these remaining values expose IFormattable or
            // object.ToString. The original provider, format and null dispatch are preserved.
            string text = value is IFormattable
                ? ((IFormattable)value).ToString(format, _provider)
                : value?.ToString();
            if (text != null) AppendLiteral(text);
        }

        public void AppendFormatted<T>(T value, int alignment)
        {
            int startingPos = _pos;
            AppendFormatted(value);
            if (alignment != 0) AppendOrInsertAlignmentIfNeeded(startingPos, alignment);
        }

        public void AppendFormatted<T>(T value, int alignment, string format)
        {
            int startingPos = _pos;
            AppendFormatted(value, format);
            if (alignment != 0) AppendOrInsertAlignmentIfNeeded(startingPos, alignment);
        }

        public void AppendFormatted(string value, int alignment = 0, string format = null)
            => AppendFormatted<string>(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null)
            => AppendFormatted<object>(value, alignment, format);

        public void AppendFormatted(scoped ReadOnlySpan<char> value)
        {
            if (value.TryCopyTo(_chars.Slice(_pos))) _pos += value.Length;
            else
            {
                Grow(value.Length);
                value.CopyTo(_chars.Slice(_pos));
                _pos += value.Length;
            }
        }

        public void AppendFormatted(scoped ReadOnlySpan<char> value, int alignment = 0, string format = null)
        {
            bool leftAlign = false;
            if (alignment < 0)
            {
                leftAlign = true;
                alignment = unchecked(-alignment);
            }

            int paddingRequired = unchecked(alignment - value.Length);
            if (paddingRequired <= 0)
            {
                AppendFormatted(value);
                return;
            }

            EnsureCapacityForAdditionalChars(unchecked(value.Length + paddingRequired));
            if (leftAlign)
            {
                value.CopyTo(_chars.Slice(_pos));
                _pos += value.Length;
                _chars.Slice(_pos, paddingRequired).Fill(' ');
                _pos += paddingRequired;
            }
            else
            {
                _chars.Slice(_pos, paddingRequired).Fill(' ');
                _pos += paddingRequired;
                value.CopyTo(_chars.Slice(_pos));
                _pos += value.Length;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool HasCustomFormatter(IFormatProvider provider)
            => provider.GetType() != typeof(CultureInfo) && provider.GetFormat(typeof(ICustomFormatter)) != null;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AppendCustomFormatter<T>(T value, string format)
        {
            var formatter = (ICustomFormatter)_provider.GetFormat(typeof(ICustomFormatter));
            if (formatter != null)
            {
                string text = formatter.Format(format, value, _provider);
                if (text != null) AppendLiteral(text);
            }
        }

        private void AppendOrInsertAlignmentIfNeeded(int startingPos, int alignment)
        {
            int charsWritten = _pos - startingPos;
            bool leftAlign = false;
            if (alignment < 0)
            {
                leftAlign = true;
                alignment = unchecked(-alignment);
            }

            int paddingNeeded = unchecked(alignment - charsWritten);
            if (paddingNeeded > 0)
            {
                EnsureCapacityForAdditionalChars(paddingNeeded);
                if (leftAlign) _chars.Slice(_pos, paddingNeeded).Fill(' ');
                else
                {
                    _chars.Slice(startingPos, charsWritten).CopyTo(_chars.Slice(startingPos + paddingNeeded));
                    _chars.Slice(startingPos, paddingNeeded).Fill(' ');
                }

                _pos += paddingNeeded;
            }
        }

        // The source FNA Vector2 is neither IFormattable nor ISpanFormattable.
        // Invoke its sole source formatter inside the append's non-formattable branch.
        public void AppendFormattedSourceVector2(Vector2 value)
        {
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, null);
                return;
            }

            string text = SourceVector2Formatting.Format(value);
            if (text != null)
                AppendLiteral(text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnsureCapacityForAdditionalChars(int additionalChars)
        {
            if (_chars.Length - _pos < additionalChars)
                Grow(additionalChars);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void GrowThenCopyString(string value)
        {
            Grow(value.Length);
            value.AsSpan().CopyTo(_chars.Slice(_pos));
            _pos += value.Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow(int additionalChars) => GrowCore(unchecked((uint)(_pos + additionalChars)));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow() => GrowCore(unchecked((uint)(_chars.Length + 1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void GrowCore(uint requiredMinCapacity)
        {
            uint value = Math.Max(requiredMinCapacity, Math.Min(unchecked((uint)(_chars.Length * 2)), 1073741791u));
            // Source Math.Clamp(value, 256u, int.MaxValue), with constant valid bounds.
            int minimumLength = unchecked((int)(value < 256u ? 256u : value > 2147483647u ? 2147483647u : value));
            char[] array = ArrayPool<char>.Shared.Rent(minimumLength);
            _chars.Slice(0, _pos).CopyTo(array);
            char[] arrayToReturnToPool = _arrayToReturnToPool;
            _chars = (_arrayToReturnToPool = array);
            if (arrayToReturnToPool != null)
                ArrayPool<char>.Shared.Return(arrayToReturnToPool);
        }
    }
}
