using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        public static void ReloadAssets(bool levels, bool graphics, bool hires,
            OriginalAreaKey? area = null)
        {
            if (levels) ReloadLevels(area);
            if (graphics) ReloadGraphics(hires);
        }

        public static void ReloadLevels(OriginalAreaKey? area = null)
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
