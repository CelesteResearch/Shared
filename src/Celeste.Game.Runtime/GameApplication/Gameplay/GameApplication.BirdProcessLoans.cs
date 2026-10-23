using Celeste.Input.Bindings;
using System;
using System.Numerics;
using Celeste.Game.Entities.Birds;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalBirdProcess, IBirdTutorialResources,
        global::Celeste.Simulation.Gameplay.Holdables.TheoCrystal.ITheoCrystalTutorialResources
    {
        string global::Celeste.Simulation.Gameplay.Holdables.TheoCrystal.ITheoCrystalTutorialResources.
            CleanDialog(string name)
            => Text.CleanDialog(name);

        // These are the original bird's process fields and GUI button registrations.
        // All resources below are loans from the same actual game process.
        private readonly OriginalBirdProcessState sourceOriginalBirdState = new();
        private readonly BirdTutorialButtonMap sourceBirdTutorialButtonMap = new();
        OriginalBirdProcessState IOriginalBirdProcess.BirdState => sourceOriginalBirdState;
        IBirdTutorialResources IOriginalBirdProcess.BirdTutorialResources => this;
        bool IOriginalBirdProcess.Invincible => SaveContext.CurrentSave.Assists.Invincible;
        ActiveBitmapFont IBirdTutorialResources.ActiveFont => ActiveFont;
        bool IBirdTutorialResources.MirrorMode => SaveContext.CurrentSave.Assists.MirrorMode;

        BirdTutorialButton IBirdTutorialResources.RegisterButton(SourceVirtualButton button)
            => sourceBirdTutorialButtonMap.Register(button);

        AtlasEntry IBirdTutorialResources.GuiButton(BirdTutorialButton prompt)
        {
            if (!sourceBirdTutorialButtonMap.TryGetButton(prompt, out SourceVirtualButton button))
            {
                button = prompt switch
                {
                    BirdTutorialButton.Dash => InputSource.Dash,
                    BirdTutorialButton.Jump => InputSource.Jump,
                    BirdTutorialButton.Grab => InputSource.Grab,
                    BirdTutorialButton.Talk => InputSource.Talk,
                    _ => InputSource.Jump
                };
            }

            return InputSource.GuiButton(button);
        }

        AtlasEntry IBirdTutorialResources.GuiDirection(Vector2 direction)
            => InputSource.GuiDirection(direction);
    }
}
