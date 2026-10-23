using Celeste.Core.Text;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void LogModuleSourceSite1(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(36, 1);
            str.AppendFormatted(module.GetType().FullName);
            str.AppendLiteral(" doesn't support save data async IO!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite2(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(32, 1);
            str.AppendLiteral("Failed to load the settings of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite3(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(32, 1);
            str.AppendLiteral("Failed to save the settings of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite4(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(33, 1);
            str.AppendLiteral("Failed to read the save data of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite5(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(34, 1);
            str.AppendLiteral("Failed to write the save data of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite6(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(40, 1);
            str.AppendLiteral("Failed to deserialize the save data of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite7(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(38, 1);
            str.AppendLiteral("Failed to serialize the save data of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite8(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(31, 1);
            str.AppendLiteral("Failed to read the session of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite9(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(32, 1);
            str.AppendLiteral("Failed to write the session of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite10(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(38, 1);
            str.AppendLiteral("Failed to deserialize the session of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite11(SourceEverestModule module)
        {
            if (!shouldLog("EverestModule", EverestLogLevel.Warn)) return;
            var str = new SourceDefaultInterpolatedStringHandler(36, 1);
            str.AppendLiteral("Failed to serialize the session of ");
            str.AppendFormatted(module.Metadata.Name);
            str.AppendLiteral("!");
            LogUnchecked(EverestLogLevel.Warn, "EverestModule", str.ToStringAndClear());
        }

        public void LogModuleSourceSite12(SourceEverestModule module)
        {
            if (!shouldLog("core", EverestLogLevel.Info)) return;
            var str = new SourceDefaultInterpolatedStringHandler(36, 2);
            str.AppendLiteral("Registered code module ");
            str.AppendFormatted(module.GetType().FullName);
            str.AppendLiteral(" for module ");
            str.AppendFormatted(module.Metadata?.ToString());
            str.AppendLiteral(".");
            LogUnchecked(EverestLogLevel.Info, "core", str.ToStringAndClear());
        }

        public void LogModuleSourceSite13(SourceEverestModule module)
        {
            if (!shouldLog("core", EverestLogLevel.Info)) return;
            var str = new SourceDefaultInterpolatedStringHandler(38, 2);
            str.AppendLiteral("Unregistered code module ");
            str.AppendFormatted(module.GetType().FullName);
            str.AppendLiteral(" for module ");
            str.AppendFormatted(module.Metadata?.ToString());
            str.AppendLiteral(".");
            LogUnchecked(EverestLogLevel.Info, "core", str.ToStringAndClear());
        }
    }
}
