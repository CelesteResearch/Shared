using System;
using Celeste.Everest.Input.Gui;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Input.Gui;
using Celeste.Game.Profiles;
using Celeste.Game.Save.Data;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameInputProcessEnvironment,
        IOriginalGameInputSourceEnvironment, ISourceGameInputEnvironment,
        IOriginalInputGuiProcess, IOriginalInputGuiPolicyEnvironment, ISourceRumbleEnvironment
    {
        private IOriginalInputGuiPolicy sourceInputGuiPolicy;
        public ISourceGameInput Input => InputSource;
        public OriginalGameInputProcess InputGui => InputSource;

        public IOriginalInputGuiPolicy InputGuiPolicy => sourceInputGuiPolicy ??
                                                         throw new InvalidOperationException(
                                                             "The actual Input GUI policy is not constructed.");

        IOriginalGameInputSourceSettings IOriginalGameInputSourceEnvironment.InputSourceSettings =>
            SettingsProcess.Instance;

        OriginalSaveDataState IOriginalGameInputSourceEnvironment.CurrentSave =>
            ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;

        AtlasData IOriginalGameInputSourceEnvironment.GuiAtlas =>
            ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas;

        public void ConstructSourceInputGuiPolicy()
        {
            if (sourceInputGuiPolicy != null)
                throw new InvalidOperationException("The actual Input GUI policy is already constructed.");
            sourceInputGuiPolicy = SourceProfile ==
                                   GameProfile.Original
                ? new OriginalInputGuiPolicy()
                : new InstalledInputGuiPolicy(
                    (ISourceFnaGamePadEnvironment)engine);
        }
    }
}
