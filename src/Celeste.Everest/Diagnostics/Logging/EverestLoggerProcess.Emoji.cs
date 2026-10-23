using System.Collections.Generic;
using Celeste.Core.Text;
using Celeste.Everest.Text.BitmapFonts;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        internal void VerboseEmojiCache(string name, string key, string value,
            Dictionary<string, SourceStringCacheValueNode> cache)
        {
            if (!shouldLog("CacheHelper", EverestLogLevel.Verbose)) return;
            var message = new SourceDefaultInterpolatedStringHandler(42, 4);
            message.AppendLiteral("[");
            message.AppendFormatted(name);
            message.AppendLiteral("] Cached value for \"");
            message.AppendFormatted(key);
            message.AppendLiteral("\" => \"");
            message.AppendFormatted(value);
            message.AppendLiteral("\", cache size: ");
            message.AppendFormatted(cache.Count);
            LogUnchecked(EverestLogLevel.Verbose, "CacheHelper", message.ToStringAndClear());
        }
    }
}
