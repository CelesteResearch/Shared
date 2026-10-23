using Celeste.Game.Settings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSettingsAfterLoadEnvironment
    {
        int IOriginalSettingsAfterLoadEnvironment.CurrentDisplayWidth =>
            GraphicsAdapters.DefaultAdapter.CurrentDisplayMode.Width;

        int IOriginalSettingsAfterLoadEnvironment.CurrentDisplayHeight =>
            GraphicsAdapters.DefaultAdapter.CurrentDisplayMode.Height;
    }
}
