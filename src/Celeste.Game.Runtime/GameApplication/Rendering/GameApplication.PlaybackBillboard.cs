using Celeste.Everest.Entities.PlaybackBillboard;
using Celeste.Game.Entities.PlaybackBillboard;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IPlaybackBillboardColorsEnvironment
    {
        private IPlaybackBillboardColors sourcePlaybackBillboardColors;

        public IPlaybackBillboardColors PlaybackBillboardColors => sourcePlaybackBillboardColors ??=
            SourceProfile == GameProfile.InstalledEverest
                ? new EverestPlaybackBillboardColors(
                    ScalarArithmetic)
                : new OriginalPlaybackBillboardColors(ScalarArithmetic);
    }
}
