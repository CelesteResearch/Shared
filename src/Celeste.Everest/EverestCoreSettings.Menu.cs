using Celeste.Core.Display;
#nullable enable annotations
using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.Controls;
using Celeste.Everest.Runtime;
using Celeste.Everest.Runtime.Discord;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Everest
{
    public partial class EverestCoreSettings
    {
        private static OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)ActualEngine).GameGraphics;

        private static OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)ActualEngine).Text;

        private static OriginalGameInputProcess InputSource =>
            ((IOriginalGameInputProcessEnvironment)ActualEngine).InputSource;

        private static IEverestDiscordSdkProcess? DiscordSdk =>
            ((IEverestDiscordSdkEnvironment)ActualEngine).DiscordSdk;

        private static EverestFlagsProcess RuntimeFlags => ((IEverestFlagsEnvironment)ActualEngine).Flags;

        public void CreateInputGuiEntry(TextMenuPresentation menu, bool inGame)
        {
            List<string> inputGuiPrefixes = new List<string> { "" };
            foreach (KeyValuePair<string, AtlasEntry> texture in Graphics.GuiAtlas.Entries)
            {
                string key = texture.Key;
                if (!key.StartsWith("controls/"))
                {
                    continue;
                }

                key = key.Substring(9);
                int num = key.IndexOf('/');
                if (num != -1)
                {
                    key = key.Substring(0, num);
                    if (!inputGuiPrefixes.Contains(key))
                    {
                        inputGuiPrefixes.Add(key);
                    }
                }
            }

            menu.Add(new TextMenuPresentation.Slider(Text.Dialog.Clean("modoptions_coremodule_inputgui"),
                delegate(int i)
                {
                    string text = inputGuiPrefixes[i];
                    return EverestModuleDialogText.CleanOrNull(ActualEngine,
                        "modoptions_coremodule_inputgui_" + text.ToLowerInvariant()) ?? text.ToUpperInvariant();
                }, 0, inputGuiPrefixes.Count - 1, Math.Max(0, inputGuiPrefixes.IndexOf(InputGui))).Change(
                delegate(int i)
                {
                    InputGui = inputGuiPrefixes[i];
                    InputSource.OverrideInputPrefix = inputGuiPrefixes[i];
                }));
        }

        public void CreateMainMenuModeEntry(TextMenuPresentation menu, bool inGame)
        {
            if (!inGame)
            {
                List<string> types = new List<string> { "", "rows" };
                menu.Add(new TextMenuPresentation.Slider(Text.Dialog.Clean("modoptions_coremodule_mainmenumode"),
                    delegate(int i)
                    {
                        string text = types[i];
                        return EverestModuleDialogText.CleanOrNull(ActualEngine,
                            "modoptions_coremodule_mainmenumode_" + text.ToLowerInvariant()) ?? text.ToUpperInvariant();
                    }, 0, types.Count - 1, Math.Max(0, types.IndexOf(MainMenuMode))).Change(delegate(int i)
                {
                    MainMenuMode = types[i];
                }));
            }
        }

        public void CreateCompatibilityModeEntry(TextMenuPresentation menu, bool inGame)
        {
            if (!inGame)
            {
                TextMenuPresentation.Slider slider = new TextMenuPresentation.Slider(
                    Text.Dialog.Clean("modoptions_coremodule_compatmode"),
                    (int i) => Text.Dialog.Clean("modoptions_coremodule_compatmode_" +
                                                 Enum.GetName(typeof(EverestCompatMode), (EverestCompatMode)i)), 0,
                    Enum.GetValues(typeof(EverestCompatMode)).Length - 1, (int)CompatibilityMode);
                slider.OnValueChange = (Action<int>)Delegate.Combine(slider.OnValueChange,
                    (Action<int>)delegate(int val) { CompatibilityMode = (EverestCompatMode)val; });
                menu.Add(slider);
                slider.NeedsRelaunch(menu);
                EverestMenuEaseInSubHeaderExt descrTextA =
                    new EverestMenuEaseInSubHeaderExt(
                        Text.Dialog.Clean("modoptions_coremodule_compatmode_" +
                                          Enum.GetName(typeof(EverestCompatMode), CompatibilityMode) + "_descr_a"),
                        initiallyVisible: false, menu)
                    {
                        TextColor = PackedColor.Gray,
                        HeightExtra = 0f
                    };
                EverestMenuEaseInSubHeaderExt descrTextB =
                    new EverestMenuEaseInSubHeaderExt(
                        Text.Dialog.Clean("modoptions_coremodule_compatmode_" +
                                          Enum.GetName(typeof(EverestCompatMode), CompatibilityMode) + "_descr_b"),
                        initiallyVisible: false, menu)
                    {
                        TextColor = PackedColor.DarkOrange,
                        HeightExtra = 0f
                    };
                menu.Insert(menu.Items.IndexOf(slider) + 1, descrTextA);
                menu.Insert(menu.Items.IndexOf(slider) + 2, descrTextB);
                slider.OnEnter = (Action)Delegate.Combine(slider.OnEnter, (Action)delegate
                {
                    EverestMenuEaseInSubHeaderExt easeInSubHeaderExt = descrTextA;
                    bool fadeVisible = (descrTextB.FadeVisible = true);
                    easeInSubHeaderExt.FadeVisible = fadeVisible;
                });
                slider.OnLeave = (Action)Delegate.Combine(slider.OnLeave, (Action)delegate
                {
                    EverestMenuEaseInSubHeaderExt easeInSubHeaderExt = descrTextA;
                    bool fadeVisible = (descrTextB.FadeVisible = false);
                    easeInSubHeaderExt.FadeVisible = fadeVisible;
                });
                slider.OnValueChange = (Action<int>)Delegate.Combine(slider.OnValueChange,
                    (Action<int>)delegate(int val)
                    {
                        descrTextA.Title = Text.Dialog.Clean("modoptions_coremodule_compatmode_" +
                                                             Enum.GetName(typeof(EverestCompatMode),
                                                                 (EverestCompatMode)val) +
                                                             "_descr_a");
                        descrTextB.Title = Text.Dialog.Clean("modoptions_coremodule_compatmode_" +
                                                             Enum.GetName(typeof(EverestCompatMode),
                                                                 (EverestCompatMode)val) +
                                                             "_descr_b");
                        menu.RecalculateSize();
                    });
                EverestMenuEaseInSubHeaderExt warningText =
                    new EverestMenuEaseInSubHeaderExt(
                        Text.Dialog.Clean("modoptions_coremodule_compatmode_incompatible"),
                        initiallyVisible: false, menu)
                    {
                        TextColor = PackedColor.OrangeRed,
                        HeightExtra = 0f
                    };
                menu.Insert(menu.Items.IndexOf(descrTextB) + 1, warningText);
                slider.OnEnter = (Action)Delegate.Combine(slider.OnEnter,
                    (Action)delegate { warningText.FadeVisible = IsCompatible(CompatibilityMode); });
                slider.OnLeave =
                    (Action)Delegate.Combine(slider.OnLeave, (Action)delegate { warningText.FadeVisible = false; });
                slider.OnValueChange = (Action<int>)Delegate.Combine(slider.OnValueChange,
                    (Action<int>)delegate(int val) { warningText.FadeVisible = IsCompatible((EverestCompatMode)val); });
            }

            bool IsCompatible(EverestCompatMode mode)
            {
                if (!RuntimeFlags.VanillaIsFNA || mode != EverestCompatMode.LegacyXNA)
                {
                    if (RuntimeFlags.VanillaIsXNA)
                    {
                        return mode == EverestCompatMode.LegacyFNA;
                    }

                    return false;
                }

                return true;
            }
        }

        public void CreateDiscordRichPresenceEntry(TextMenuPresentation menu, bool inGame)
        {
            ChapterCompletionSession session =
                (ActualEngine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Session;
            TextMenuPresentation.Option<bool> showSide =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordshowside"),
                    DiscordShowSide,
                    ActualEngine).Change(delegate(bool value)
                {
                    DiscordShowSide = value;
                    DiscordSdk?.Instance?.UpdatePresence(session);
                });
            TextMenuPresentation.Option<bool> showRoom =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordshowroom"),
                    DiscordShowRoom,
                    ActualEngine).Change(delegate(bool value)
                {
                    DiscordShowRoom = value;
                    DiscordSdk?.Instance?.UpdatePresence(session);
                });
            TextMenuPresentation.Item item =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordshowmap"),
                    DiscordShowMap,
                    ActualEngine).Change(delegate(bool value)
                {
                    DiscordShowMap = value;
                    DiscordSdk?.Instance?.UpdatePresence(session);
                    showSide.Disabled = !DiscordShowMap;
                    showRoom.Disabled = !DiscordShowMap;
                    if (!DiscordShowMap)
                    {
                        showSide.Index = 0;
                        showRoom.Index = 0;
                        DiscordShowSide = false;
                        DiscordShowRoom = false;
                    }
                });
            TextMenuPresentation.Item item2 =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordshowicon"),
                    DiscordShowIcon,
                    ActualEngine).Change(delegate(bool value)
                {
                    DiscordShowIcon = value;
                    DiscordSdk?.Instance?.UpdatePresence(session);
                });
            TextMenuPresentation.Item item3 =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordshowdeaths"),
                    DiscordShowDeaths, ActualEngine).Change(delegate(bool value)
                {
                    DiscordShowDeaths = value;
                    DiscordSdk?.Instance?.UpdatePresence(session);
                });
            TextMenuPresentation.Item item4 =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordshowberries"),
                    DiscordShowBerries, ActualEngine).Change(delegate(bool value)
                {
                    DiscordShowBerries = value;
                    DiscordSdk?.Instance?.UpdatePresence(session);
                });
            EverestSubMenu submenu =
                new EverestSubMenu(menu.Resources,
                        Text.Dialog.Clean("modoptions_coremodule_discordrichpresenceoptions"),
                        enterOnSelect: false).Add(item2).Add(item).Add(showSide)
                    .Add(showRoom)
                    .Add(item3)
                    .Add(item4);
            EverestMenuEaseInSubHeaderExt failureWarning =
                new EverestMenuEaseInSubHeaderExt(Text.Dialog.Clean("modoptions_coremodule_discordfailed"),
                    initiallyVisible: false, menu)
                {
                    TextColor = PackedColor.Goldenrod,
                    HeightExtra = 0f
                };
            TextMenuPresentation.Item item5 =
                new TextMenuPresentation.OnOff(Text.Dialog.Clean("modoptions_coremodule_discordrichpresence"),
                    DiscordRichPresence, ActualEngine).Change(delegate(bool value)
                {
                    DiscordRichPresence = value;
                    if (DiscordRichPresence && !((IEverestHeadlessEnvironment)ActualEngine).IsHeadless)
                    {
                        DiscordSdk?.CreateInstance()?.UpdatePresence(session);
                    }
                    else
                    {
                        DiscordSdk?.Instance?.Dispose();
                    }

                    submenu.Disabled = !value;
                    failureWarning.FadeVisible = DiscordRichPresence && DiscordSdk?.Instance == null;
                });
            item5.OnEnter = (Action)Delegate.Combine(item5.OnEnter,
                (Action)delegate { failureWarning.FadeVisible = DiscordRichPresence && DiscordSdk?.Instance == null; });
            item5.OnLeave =
                (Action)Delegate.Combine(item5.OnLeave, (Action)delegate { failureWarning.FadeVisible = false; });
            menu.Add(item5);
            menu.Add(failureWarning);
            submenu.Disabled = !DiscordRichPresence;
            showSide.Disabled = !DiscordShowMap;
            showRoom.Disabled = !DiscordShowMap;
            menu.Add(submenu);
        }

        public void CreateMirrorPreferencesEntry(TextMenuPresentation menu, bool inGame)
        {
            if (!inGame)
            {
                List<string> mirrorPreferences = new List<string>
                {
                    "gb,jade,risingsunlight,otobot,wegfan", "jade,risingsunlight,otobot,wegfan,gb",
                    "wegfan,otobot,jade,risingsunlight,gb", "otobot,jade,risingsunlight,wegfan,gb",
                    "risingsunlight,jade,otobot,wegfan,gb"
                };
                List<string> dialogKeys = mirrorPreferences.Select((string setting) =>
                    "MODOPTIONS_COREMODULE_MIRRORPREFERENCES_" + setting.Substring(0, setting.IndexOf(","))).ToList();
                menu.Add(new TextMenuPresentation.Slider(Text.Dialog.Clean("MODOPTIONS_COREMODULE_MIRRORPREFERENCES"),
                    (int index) => Text.Dialog.Clean(dialogKeys[index]), 0, mirrorPreferences.Count - 1,
                    mirrorPreferences.IndexOf(MirrorPreferences)).Change(delegate(int value)
                {
                    MirrorPreferences = mirrorPreferences[value];
                }));
            }
        }
    }
}
