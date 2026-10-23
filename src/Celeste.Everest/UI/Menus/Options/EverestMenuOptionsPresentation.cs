using System;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.UI.Settings;
using Celeste.Game.Menus.Options;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Menus.Options
{
    public sealed class EverestMenuOptionsPresentation : MenuOptionsPresentation
    {
        private EverestCoreSettings CoreSettings =>
            ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;

        public EverestMenuOptionsPresentation(ISourceEngineContext engine) : base(engine)
        {
        }

        public override TextMenuPresentation Create(bool inGame = false, FmodEventReference snapshot = null)
        {
            var textMenu = base.Create(inGame, snapshot);
            var num = textMenu.Items.FindIndex(item7 =>
                item7.GetType() == typeof(TextMenuPresentation.OnOff) && ((TextMenuPresentation.OnOff)item7).Label ==
                Dialog.Clean("OPTIONS_DISABLE_FLASH"));
            TextMenuPresentation.Item item =
                new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_COREMODULE_PSDISTORT"),
                    CoreSettings.PhotosensitivityDistortOverride, engine).Change(delegate(bool value)
                {
                    CoreSettings.PhotosensitivityDistortOverride = value;
                });
            var distortDesc =
                new EverestMenuEaseInSubHeaderExt(Dialog.Clean("MODOPTIONS_COREMODULE_PSDISTORT_DESC"),
                    false, textMenu)
                {
                    HeightExtra = 0f,
                };
            item.OnEnter = (Action)Delegate.Combine(item.OnEnter, (Action)delegate { distortDesc.FadeVisible = true; });
            item.OnLeave =
                (Action)Delegate.Combine(item.OnLeave, (Action)delegate { distortDesc.FadeVisible = false; });
            TextMenuPresentation.Item item2 =
                new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_COREMODULE_PSGLITCH"),
                    CoreSettings.PhotosensitivityGlitchOverride, engine).Change(delegate(bool value)
                {
                    CoreSettings.PhotosensitivityGlitchOverride = value;
                });
            var glitchDesc =
                new EverestMenuEaseInSubHeaderExt(Dialog.Clean("MODOPTIONS_COREMODULE_PSGLITCH_DESC"),
                    false, textMenu)
                {
                    HeightExtra = 0f,
                };
            item2.OnEnter =
                (Action)Delegate.Combine(item2.OnEnter, (Action)delegate { glitchDesc.FadeVisible = true; });
            item2.OnLeave =
                (Action)Delegate.Combine(item2.OnLeave, (Action)delegate { glitchDesc.FadeVisible = false; });
            TextMenuPresentation.Item item3 =
                new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_COREMODULE_PSLIGHTNING"),
                    CoreSettings.PhotosensitivityLightningOverride, engine).Change(delegate(bool value)
                {
                    CoreSettings.PhotosensitivityLightningOverride = value;
                });
            var lightningDesc =
                new EverestMenuEaseInSubHeaderExt(Dialog.Clean("MODOPTIONS_COREMODULE_PSLIGHTNING_DESC"),
                    false, textMenu)
                {
                    HeightExtra = 0f,
                };
            item3.OnEnter =
                (Action)Delegate.Combine(item3.OnEnter, (Action)delegate { lightningDesc.FadeVisible = true; });
            item3.OnLeave =
                (Action)Delegate.Combine(item3.OnLeave, (Action)delegate { lightningDesc.FadeVisible = false; });
            TextMenuPresentation.Item item4 =
                new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_COREMODULE_PSSCREENFLASH"),
                    CoreSettings.PhotosensitivityScreenFlashOverride, engine).Change(delegate(bool value)
                {
                    CoreSettings.PhotosensitivityScreenFlashOverride = value;
                });
            var screenFlashDesc =
                new EverestMenuEaseInSubHeaderExt(Dialog.Clean("MODOPTIONS_COREMODULE_PSSCREENFLASH_DESC"),
                    false, textMenu)
                {
                    HeightExtra = 0f,
                };
            item4.OnEnter =
                (Action)Delegate.Combine(item4.OnEnter, (Action)delegate { screenFlashDesc.FadeVisible = true; });
            item4.OnLeave =
                (Action)Delegate.Combine(item4.OnLeave, (Action)delegate { screenFlashDesc.FadeVisible = false; });
            TextMenuPresentation.Item item5 =
                new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_COREMODULE_PSTEXTHIGHLIGHT"),
                    CoreSettings.PhotosensitivityTextHighlightOverride, engine).Change(delegate(bool value)
                {
                    CoreSettings.PhotosensitivityTextHighlightOverride = value;
                });
            var textHighlightDesc =
                new EverestMenuEaseInSubHeaderExt(Dialog.Clean("MODOPTIONS_COREMODULE_PSTEXTHIGHLIGHT_DESC"),
                    false, textMenu)
                {
                    HeightExtra = 0f,
                };
            item5.OnEnter =
                (Action)Delegate.Combine(item5.OnEnter, (Action)delegate { textHighlightDesc.FadeVisible = true; });
            item5.OnLeave =
                (Action)Delegate.Combine(item5.OnLeave, (Action)delegate { textHighlightDesc.FadeVisible = false; });
            var submenu =
                new EverestSubMenu(textMenu.Resources, Dialog.Clean("MODOPTIONS_COREMODULE_PSOPTIONS"),
                        false).Add(item).Add(distortDesc).Add(item2)
                    .Add(glitchDesc)
                    .Add(item3)
                    .Add(lightningDesc)
                    .Add(item4)
                    .Add(screenFlashDesc)
                    .Add(item5)
                    .Add(textHighlightDesc);
            TextMenuPresentation.Item item6 =
                new TextMenuPresentation.OnOff(Dialog.Clean("OPTIONS_DISABLE_FLASH"), Settings.DisableFlashes, engine)
                    .Change(delegate(bool value)
                    {
                        Settings.DisableFlashes = value;
                        submenu.Disabled = !value;
                    });
            textMenu.Remove(textMenu.Items[num]);
            textMenu.Insert(num, item6);
            textMenu.Insert(num + 1, submenu);
            submenu.Disabled = !Settings.DisableFlashes;
            return textMenu;
        }
    }
}
