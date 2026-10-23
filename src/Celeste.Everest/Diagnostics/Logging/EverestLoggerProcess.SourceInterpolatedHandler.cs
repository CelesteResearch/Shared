using System;
using Celeste.Core.Text;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public ref struct LogInterpolatedStringHandler
        {
            private SourceDefaultInterpolatedStringHandler handler;
            public bool ShouldLog { get; }

            public LogInterpolatedStringHandler(int literalLength, int formattedCount,
                EverestLoggerProcess logger, EverestLogLevel level, string tag, out bool shouldLog)
            {
                handler = default;
                ShouldLog = shouldLog = logger.shouldLog(tag, level);
                if (shouldLog) handler = new(literalLength, formattedCount);
            }

            internal string ToStringAndClear()
            {
                return handler.ToStringAndClear();
            }

            public void AppendLiteral(string text)
            {
                handler.AppendLiteral(text);
            }

            public void AppendFormatted<T>(T value)
            {
                handler.AppendFormatted(value);
            }

            public void AppendFormatted<T>(T value, string format)
            {
                handler.AppendFormatted(value, format);
            }

            public void AppendFormatted<T>(T value, int alignment)
            {
                handler.AppendFormatted(value, alignment);
            }

            public void AppendFormatted<T>(T value, int alignment, string format)
            {
                handler.AppendFormatted(value, alignment, format);
            }

            public void AppendFormatted(scoped ReadOnlySpan<char> value)
            {
                handler.AppendFormatted(value);
            }

            public void AppendFormatted(scoped ReadOnlySpan<char> value, int alignment, string format = null)
            {
                handler.AppendFormatted(value, alignment, format);
            }

            public void AppendFormatted(string value)
            {
                handler.AppendFormatted(value);
            }

            public void AppendFormatted(string value, int alignment, string format = null)
            {
                handler.AppendFormatted(value, alignment, format);
            }
        }

        public void Log(EverestLogLevel level, string tag, LogInterpolatedStringHandler message)
        {
            if (message.ShouldLog) LogUnchecked(level, tag, message.ToStringAndClear());
        }
    }
}
