using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Core;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.UI.Menus.Buttons.Title;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.UI.Menus.Buttons
{
    internal class MainMenuModOptionsButton : MainMenuSmallButtonPresentation
    {
        private readonly string subText;
        public bool SmallSubTextSpacing;
        public override float ButtonHeight => ActiveFont.LineHeight * (subText == null ? 1.25f : 1.75f);

        public MainMenuModOptionsButton(string labelName, string iconName, OuiState owner,
            Vector2 targetPosition, Vector2 tweenFrom, Action onConfirm, AtlasData gui, ISourceEngineContext engine)
            : base(labelName, iconName, owner, targetPosition, tweenFrom, onConfirm, gui, engine)
        {
            var loader = ((IEverestLoaderProcessEnvironment)engine).Loader;
            var failures = loader.Delayed.Count + loader.ModsWithAssemblyLoadFailures.Count;
            var updater = ((IEverestModUpdaterEnvironment)engine).ModUpdater;
            var updates = updater.IsAsyncUpdateCheckingDone() ? updater.GetAsyncLoadedModUpdates()?.Count ?? 0 : 0;
            var everestUpdater = ((IEverestUpdaterEnvironment)engine).Updater;
            var text = ((IOriginalGameTextEnvironment)engine).Text;
            if (everestUpdater.UpdateFailed)
                subText = text.CleanDialog("MENU_MODOPTIONS_UPDATE_FAILED");
            else if (failures > 1)
                subText = string.Format(text.Dialog.Get("MENU_MODOPTIONS_MULTIPLE_MODS_FAILEDTOLOAD"), failures);
            else if (failures == 1)
                subText = text.CleanDialog("MENU_MODOPTIONS_ONE_MOD_FAILEDTOLOAD");
            else if (everestUpdater.HasUpdate)
                subText = text.CleanDialog("MENU_MODOPTIONS_UPDATE_AVAILABLE");
            else if (updates > 1)
                subText = string.Format(text.Dialog.Get("MENU_MODOPTIONS_MOD_UPDATES_AVAILABLE"), updates);
            else if (updates == 1)
                subText = text.CleanDialog("MENU_MODOPTIONS_MOD_UPDATE_AVAILABLE");
            else if (SourceCoreModule.Settings.WarnOnEverestYamlErrors &&
                     loader.FilesWithMetadataLoadFailures.Count > 0)
                subText = text.CleanDialog("MENU_MODOPTIONS_EVEREST_YAML_ERRORS");
            else
                subText = null;
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (!(subText != null))
                return;
            var offset = new Vector2(
                ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeInOut(Ease) * 32f,
                Wiggler.Value * 8f);
            ActiveFont.DrawOutline(context, this, subText,
                Position + offset + new Vector2(84f, SmallSubTextSpacing ? 70f : 84f),
                new(0f, 0.5f), Vector2.One * 0.6f, PackedColor.OrangeRed, 2f, PackedColor.Black);
        }
    }
}
