using System;
using Celeste.Game.Profiles;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Simulation.UI.Menus.Text.Policies;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ITextMenuProcessEnvironment, ITextMenuPolicyEnvironment
    {
        private ITextMenuRuntimePolicy sourceTextMenuPolicy;
        private TextMenuResources sourceTextMenuResources;

        public TextMenuResources TextMenuResources => sourceTextMenuResources ??=
            Celeste.Game.Menus.Resources.OriginalTextMenuResourcesFactory.Create(this);

        bool ITextMenuPolicyEnvironment.DisableFlashes => SettingsProcess.Instance.DisableFlashes;
        public bool AllowTextHighlight => TextMenuPolicy.AllowTextHighlight(this);
        public bool MenuPageUpPressed => TextMenuPolicy.MenuPageUpPressed;
        public bool MenuPageDownPressed => TextMenuPolicy.MenuPageDownPressed;
        public void PlayMenuSound(string eventPath) => AudioSession.Play(eventPath);
        public int TextMenuTags => Tags.PauseUpdate.Value | Tags.HUD.Value;

        public ITextMenuRuntimePolicy TextMenuPolicy => sourceTextMenuPolicy ??
                                                        throw new InvalidOperationException(
                                                            "The actual TextMenu policy is not constructed.");

        public void ConstructSourceTextMenuPolicy()
        {
            if (sourceTextMenuPolicy != null)
                throw new InvalidOperationException("The actual TextMenu policy is already constructed.");
            sourceTextMenuPolicy = SourceProfile == GameProfile.Original
                ? (ITextMenuRuntimePolicy)new Celeste.Game.Menus.Policies.OriginalTextMenuPolicy()
                : new Celeste.Everest.UI.Menus.Policies.InstalledTextMenuPolicy(this);
        }
    }
}
