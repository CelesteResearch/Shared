using Celeste.Input.Bindings;
using System.Collections.Generic;

namespace Celeste.Simulation.Presentation.Hud.Tutorials.Birds
{
    public sealed class BirdTutorialButtonMap
    {
        private readonly Dictionary<SourceVirtualButton, BirdTutorialButton> controlsButtonsToID = new();
        private readonly Dictionary<BirdTutorialButton, SourceVirtualButton> controlsIDToButton = new();

        public BirdTutorialButton Register(SourceVirtualButton button)
        {
            if (!controlsButtonsToID.TryGetValue(button, out var value))
            {
                value = (BirdTutorialButton)(-(controlsButtonsToID.Count + 1));
                controlsButtonsToID[button] = value;
                controlsIDToButton[value] = button;
            }

            return value;
        }

        public bool TryGetButton(BirdTutorialButton prompt, out SourceVirtualButton button)
            => controlsIDToButton.TryGetValue(prompt, out button);
    }
}
