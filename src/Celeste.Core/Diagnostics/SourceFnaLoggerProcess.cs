using System;
using System.Text;

namespace Celeste.Core.Diagnostics
{
    public sealed class SourceFnaLoggerProcess
    {
        public Action<string> LogInfo;
        public Action<string> LogWarn;
        public Action<string> LogError;
        private readonly ISourceFnaLoggingDevice _device;
        private readonly SourceFnaLogFunction _infoFunction;
        private readonly SourceFnaLogFunction _warningFunction;
        private readonly SourceFnaLogFunction _errorFunction;

        public SourceFnaLoggerProcess(ISourceFnaLoggingDevice device)
        {
            _device = device;
            _infoFunction = Fna3DLogInfo;
            _warningFunction = Fna3DLogWarning;
            _errorFunction = Fna3DLogError;
        }

        public void Initialize()
        {
            if (LogInfo == null) LogInfo = Console.WriteLine;
            if (LogWarn == null) LogWarn = Console.WriteLine;
            if (LogError == null) LogError = Console.WriteLine;
        }

        public void HookFna3D()
        {
            if (_device == null) return;
            try
            {
                _device.HookLogFunctions(_infoFunction, _warningFunction, _errorFunction);
            }
            catch (DllNotFoundException)
            {
            }
        }

        private void Fna3DLogInfo(IntPtr message)
        {
            LogInfo(ReadUtf8(message));
        }

        private void Fna3DLogWarning(IntPtr message)
        {
            LogWarn(ReadUtf8(message));
        }

        private void Fna3DLogError(IntPtr message)
        {
            var text = ReadUtf8(message);
            LogError(text);
            throw new InvalidOperationException(text);
        }

        private static unsafe string ReadUtf8(IntPtr message)
        {
            byte* cursor;
            for (cursor = (byte*)(void*)message; *cursor != 0; cursor++)
            {
            }

            var length = (int)(cursor - (byte*)(void*)message);
            if (length == 0) return string.Empty;
            var chars = stackalloc char[length];
            var count = Encoding.UTF8.GetChars((byte*)(void*)message, length, chars, length);
            return new(chars, 0, count);
        }
    }
}
