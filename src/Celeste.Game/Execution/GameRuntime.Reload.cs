using global::Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        public static void ReloadAssets(bool levels, bool graphics, bool hires,
            global::Celeste.Game.Execution.Areas.OriginalAreaKey? area = null)
        {
            if (levels) ReloadLevels(area);
            if (graphics) ReloadGraphics(hires);
        }

        public static void ReloadLevels(global::Celeste.Game.Execution.Areas.OriginalAreaKey? area = null)
        {
        }

        public static void ReloadGraphics(bool hires)
        {
        }

        public static void ReloadPortraits()
        {
        }

        public static void ReloadDialog()
        {
        }
    }
}
