using Celeste.Game.Controls.Source;
using Celeste.Game.Input.Gui;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Bindings;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Everest.Input.Gui
{
    public sealed class InstalledInputGuiPolicy : IOriginalInputGuiPolicy
    {
        private readonly ISourceFnaGamePadEnvironment gamePads;

        public InstalledInputGuiPolicy(ISourceFnaGamePadEnvironment gamePads)
        {
            this.gamePads = gamePads;
        }

        public string GuiInputPrefix(OriginalGameInputProcess input, OriginalGameInputProcess.PrefixMode mode)
        {
            if (!string.IsNullOrEmpty(input.OverrideInputPrefix)) return input.OverrideInputPrefix;
            if (mode == OriginalGameInputProcess.PrefixMode.Latest
                    ? input.SourceEnvironment.MInput.ControllerHasFocus
                    : input.SourceEnvironment.MInput.GamePads[input.Gamepad].Attached)
            {
                var guid =
                    gamePads.FnaGamePads.GetGUIDEXT(input.SourceEnvironment.MInput.GamePads[input.Gamepad].PlayerIndex);
                if (guid.Equals("4c05c405") || guid.Equals("4c05cc09")) return "ps4";
                if (guid.Equals("7e050920") || guid.Equals("7e053003")) return "ns";
                return guid.Equals("d1180094") ? "stadia" : "xb1";
            }

            return "keyboard";
        }

        public AtlasEntry GuiButton(OriginalGameInputProcess input, SourceVirtualButton button,
            OriginalGameInputProcess.PrefixMode mode, string fallback)
        {
            if (!input.GuiInputController() && input.FirstKey(button) == SourceKeys.None)
                foreach (var mouse in ((InstalledSourceInputBinding)button.Binding).Mouse)
                {
                    var name = mouse.ToString();
                    var texture = input.GuiTexture("mouse", name);
                    if (texture == null && fallback != null) return input.SourceEnvironment.GuiAtlas[fallback];
                    return texture;
                }

            return input.OriginalGuiButton(button, mode, fallback);
        }
    }
}
