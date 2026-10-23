using Celeste.Game.Entities.PlaybackBillboard;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IPlaybackBillboardColorsEnvironment
    {
        private IPlaybackBillboardColors sourcePlaybackBillboardColors;

        public IPlaybackBillboardColors PlaybackBillboardColors => sourcePlaybackBillboardColors ??=
            SourceProfile == GameProfile.InstalledEverest
                ? new global::Celeste.Everest.Entities.PlaybackBillboard.EverestPlaybackBillboardColors(
                    ScalarArithmetic)
                : new OriginalPlaybackBillboardColors(ScalarArithmetic);
    }
}
