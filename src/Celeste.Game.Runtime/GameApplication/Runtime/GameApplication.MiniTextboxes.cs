using Celeste.Game.UI.Dialogue.MiniTextboxes;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMiniTextboxProcess
    {
        public MiniTextboxBehavior MiniTextboxBehavior => SourceProfile == Profile.Original
            ? MiniTextboxBehavior.Original
            : MiniTextboxBehavior.Everest;
    }
}
