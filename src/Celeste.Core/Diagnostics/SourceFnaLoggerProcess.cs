using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Celeste.Core.Diagnostics
{
    public sealed class SourceFnaLoggerProcess
    {
        public Action<string> LogInfo;
        public Action<string> LogWarn;
        public Action<string> LogError;
        private readonly ISourceFnaLoggingDevice device;
        private readonly SourceFnaLogFunction infoFunction;
        private readonly SourceFnaLogFunction warningFunction;
        private readonly SourceFnaLogFunction errorFunction;

        public SourceFnaLoggerProcess(ISourceFnaLoggingDevice device)
        {
            this.device = device;
            infoFunction = Fna3DLogInfo;
            warningFunction = Fna3DLogWarning;
            errorFunction = Fna3DLogError;
        }

        public void Initialize()
        {
            if (LogInfo == null) LogInfo = Console.WriteLine;
            if (LogWarn == null) LogWarn = Console.WriteLine;
            if (LogError == null) LogError = Console.WriteLine;
        }

        public void HookFna3D()
        {
            if (device == null) return;
            try
            {
                device.HookLogFunctions(infoFunction, warningFunction, errorFunction);
            }
            catch (DllNotFoundException)
            {
            }
        }

        private void Fna3DLogInfo(IntPtr message) => LogInfo(ReadUtf8(message));
        private void Fna3DLogWarning(IntPtr message) => LogWarn(ReadUtf8(message));

        private void Fna3DLogError(IntPtr message)
        {
            string text = ReadUtf8(message);
            LogError(text);
            throw new InvalidOperationException(text);
        }

        private static unsafe string ReadUtf8(IntPtr message)
        {
            byte* cursor;
            for (cursor = (byte*)(void*)message; *cursor != 0; cursor++)
            {
            }

            int length = (int)(cursor - (byte*)(void*)message);
            if (length == 0) return string.Empty;
            char* chars = stackalloc char[length];
            int count = Encoding.UTF8.GetChars((byte*)(void*)message, length, chars, length);
            return new string(chars, 0, count);
        }
    }
}
