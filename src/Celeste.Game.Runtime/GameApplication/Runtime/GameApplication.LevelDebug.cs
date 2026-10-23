using Celeste.Game.Execution.Levels.Debug;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelDebugEnvironment, IActiveBitmapFontEnvironment
    {
        private OriginalLevelDebugProcess sourceLevelDebug;

        SourcePixelFont IActiveBitmapFontEnvironment.Font => ActiveFont.Font;
        float IActiveBitmapFontEnvironment.BaseSize => ActiveFont.BaseSize;

        public OriginalLevelDebugProcess LevelDebug
        {
            get
            {
                if (sourceLevelDebug != null) return sourceLevelDebug;
                var services = new GameApplicationLevelDebugServices(this);
                return sourceLevelDebug = new(services, services, services);
            }
        }
    }
}
