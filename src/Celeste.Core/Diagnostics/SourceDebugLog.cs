using System.Collections.Generic;

namespace Celeste.Core.Diagnostics
{
    public static class SourceDebugLog
    {
        public static void Log()
        {
        }

        public static void Log(params object[] values)
        {
            foreach (var value in values)
            {
                _ = value;
            }
        }

        public static void LogEach<T>(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                _ = value;
            }
        }
    }
}
