using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalRotateSpinnerEnvironment
    {
        public OriginalRotateSpinnerProfile RotateSpinnerProfile => SourceProfile == GameProfile.InstalledEverest
            ? OriginalRotateSpinnerProfile.Installed
            : OriginalRotateSpinnerProfile.Original;
    }
}
