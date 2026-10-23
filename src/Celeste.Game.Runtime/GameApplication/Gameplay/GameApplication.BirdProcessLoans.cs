using System.Numerics;
using Celeste.Game.Entities.Birds;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text;
using Celeste.Input.Bindings;
using Celeste.Simulation.Gameplay.Holdables.TheoCrystal;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalBirdProcess, IBirdTutorialResources,
        ITheoCrystalTutorialResources
    {
        string ITheoCrystalTutorialResources.
            CleanDialog(string name)
        {
            return Text.CleanDialog(name);
        }

        // These are the original bird's process fields and GUI button registrations.
        // All resources below are loans from the same actual game process.
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly OriginalBirdProcessState sourceOriginalBirdState = new();

        private readonly BirdTutorialButtonMap sourceBirdTutorialButtonMap = new();
        OriginalBirdProcessState IOriginalBirdProcess.BirdState => sourceOriginalBirdState;
        IBirdTutorialResources IOriginalBirdProcess.BirdTutorialResources => this;
        bool IOriginalBirdProcess.Invincible => SaveContext.CurrentSave.Assists.Invincible;
        ActiveBitmapFont IBirdTutorialResources.ActiveFont => ActiveFont;
        bool IBirdTutorialResources.MirrorMode => SaveContext.CurrentSave.Assists.MirrorMode;

        BirdTutorialButton IBirdTutorialResources.RegisterButton(SourceVirtualButton button)
        {
            return sourceBirdTutorialButtonMap.Register(button);
        }

        AtlasEntry IBirdTutorialResources.GuiButton(BirdTutorialButton prompt)
        {
            if (!sourceBirdTutorialButtonMap.TryGetButton(prompt, out var button))
                button = prompt switch
                {
                    BirdTutorialButton.Dash => InputSource.Dash,
                    BirdTutorialButton.Jump => InputSource.Jump,
                    BirdTutorialButton.Grab => InputSource.Grab,
                    BirdTutorialButton.Talk => InputSource.Talk,
                    _ => InputSource.Jump,
                };

            return InputSource.GuiButton(button);
        }

        AtlasEntry IBirdTutorialResources.GuiDirection(Vector2 direction)
        {
            return InputSource.GuiDirection(direction);
        }
    }
}
