using Celeste.Core.Text;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void InfoLevelLoaderLoading(string sid, string suffix)
        {
            if (!shouldLog("LevelLoader", EverestLogLevel.Info)) return;
            var message = new SourceDefaultInterpolatedStringHandler(8, 2);
            message.AppendLiteral("Loading ");
            message.AppendFormatted(sid);
            message.AppendFormatted(suffix);
            LogUnchecked(EverestLogLevel.Info, "LevelLoader", message.ToStringAndClear());
        }

        public void WarnLevelLoaderStart(ChapterCompletionSession session, string sid, string suffix)
        {
            if (!shouldLog("LevelLoader", EverestLogLevel.Warn)) return;
            var message = new SourceDefaultInterpolatedStringHandler(36, 3);
            message.AppendLiteral("Failed Starting Level at room ");
            message.AppendFormatted(session.Level);
            message.AppendLiteral(" of '");
            message.AppendFormatted(sid);
            message.AppendFormatted(suffix);
            message.AppendLiteral("'");
            LogUnchecked(EverestLogLevel.Warn, "LevelLoader", message.ToStringAndClear());
        }

        public void WarnLevelLoaderTile(AutotilerException tile, string room)
        {
            if (!shouldLog("LevelLoader", EverestLogLevel.Warn)) return;
            var message = new SourceDefaultInterpolatedStringHandler(37, 4);
            message.AppendLiteral("Undefined tile id '");
            message.AppendFormatted(tile.ID);
            message.AppendLiteral("' at (");
            message.AppendFormatted(tile.X);
            message.AppendLiteral(", ");
            message.AppendFormatted(tile.Y);
            message.AppendLiteral(") in room ");
            message.AppendFormatted(room);
            LogUnchecked(EverestLogLevel.Warn, "LevelLoader", message.ToStringAndClear());
        }

        public void WarnLevelLoaderLoading(string sid, string suffix)
        {
            if (!shouldLog("LevelLoader", EverestLogLevel.Warn)) return;
            var message = new SourceDefaultInterpolatedStringHandler(15, 2);
            message.AppendLiteral("Failed loading ");
            message.AppendFormatted(sid);
            message.AppendFormatted(suffix);
            LogUnchecked(EverestLogLevel.Warn, "LevelLoader", message.ToStringAndClear());
        }
    }
}
