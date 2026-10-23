using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Input.Bindings;
using Celeste.Everest.Settings.Metadata;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Menus.Controls;
using Binding = Celeste.Input.Bindings.SourceInputBinding;
using ButtonBinding = Celeste.Everest.Input.Bindings.EverestButtonBinding;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Everest.UI.Controls
{
    public class ModuleSettingsKeyboardConfigUI : EverestKeyboardConfigPresentation
    {
        private readonly ISourceEngineContext sourceEngine;
        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)sourceEngine).Text;

        protected class ButtonBindingEntry
        {
            public ButtonBinding Binding;

            public DefaultButtonBindingAttribute Defaults;

            public ButtonBindingEntry(ButtonBinding binding, DefaultButtonBindingAttribute defaults)
            {
                Binding = binding;
                Defaults = defaults;
            }
        }

        public SourceEverestModule Module;

        protected List<ButtonBindingEntry> Bindings = new List<ButtonBindingEntry>();

        public ModuleSettingsKeyboardConfigUI(SourceEverestModule module, ISourceEngineContext engine,
            global::Celeste.Game.Menus.Options.MenuOptionsPresentation menuOptions) : base(engine, menuOptions)
        {
            sourceEngine = engine;
            ModuleSettingsKeyboardConfigUI moduleSettingsKeyboardConfigUI = this;
            Module = module;
            object scene = sourceEngine.Frame.Scenes.CurrentScene;
            Level level = scene as Level;
            if (level != null)
            {
                bool? oldAllowHudHide = null;
                OnUpdate = delegate
                {
                    if (!oldAllowHudHide.HasValue)
                    {
                        oldAllowHudHide = level.AllowHudHide;
                        level.AllowHudHide = false;
                        moduleSettingsKeyboardConfigUI.OnClose = (Action)Delegate.Combine(
                            moduleSettingsKeyboardConfigUI.OnClose,
                            (Action)delegate { level.AllowHudHide = oldAllowHudHide.Value; });
                    }
                };
            }

            Reload(2);
        }

        public override void Reload(int index = -1)
        {
            if (Module == null)
            {
                return;
            }

            Clear();
            Add(new Header(Text.CleanDialog("KEY_CONFIG_TITLE")));
            Add(new InputMappingInfoPresentation(sourceEngine, controllerMode: false));
            object settings = Module._Settings;
            string text = Module.SettingsType.Name.ToLowerInvariant();
            if (text.EndsWith("settings"))
            {
                text = text.Substring(0, text.Length - 8);
            }

            string text2 = "modoptions_" + text + "_";
            PropertyInfo[] properties = Module.SettingsType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                SettingInGameAttribute customAttribute;
                if (((customAttribute = propertyInfo.GetCustomAttribute<SettingInGameAttribute>()) == null ||
                     customAttribute.InGame == sourceEngine.Frame.Scenes.CurrentScene is Level) &&
                    propertyInfo.GetCustomAttribute<SettingIgnoreAttribute>() == null && propertyInfo.CanRead &&
                    propertyInfo.CanWrite && typeof(ButtonBinding).IsAssignableFrom(propertyInfo.PropertyType) &&
                    propertyInfo.GetValue(settings) is ButtonBinding buttonBinding)
                {
                    string input = propertyInfo.GetCustomAttribute<SettingNameAttribute>()?.Name ??
                                   (text2 + propertyInfo.Name.ToLowerInvariant());
                    input = EverestModuleDialogText.CleanOrNull(sourceEngine, input) ??
                            EverestStringSource.SpacedPascalCase(
                                propertyInfo.Name.ToLowerInvariant().StartsWith("button")
                                    ? propertyInfo.Name.Substring(6)
                                    : propertyInfo.Name);
                    DefaultButtonBindingAttribute customAttribute2 =
                        propertyInfo.GetCustomAttribute<DefaultButtonBindingAttribute>();
                    Bindings.Add(new ButtonBindingEntry(buttonBinding, customAttribute2));
                    string text3 = propertyInfo.GetCustomAttribute<SettingSubHeaderAttribute>()?.SubHeader;
                    if (text3 != null)
                    {
                        Add(new SubHeader(EverestModuleDialogText.CleanOrNull(sourceEngine, text3) ?? text3, true));
                    }

                    AddMapForceLabel(input, buttonBinding.Binding);
                }
            }

            Add(new SubHeader(""));
            Add(new Button(Text.CleanDialog("KEY_CONFIG_RESET"))
            {
                IncludeWidthInMeasurement = false,
                AlwaysCenter = true,
                OnPressed = delegate { ResetPressed(); }
            });
            if (index >= 0)
            {
                Selection = index;
            }
        }

        public override void Reset()
        {
            foreach (ButtonBindingEntry binding2 in Bindings)
            {
                Binding binding = binding2.Binding.Binding;
                binding.Keyboard.Clear();
                DefaultButtonBindingAttribute defaults = binding2.Defaults;
                if (defaults == null)
                {
                    continue;
                }

                if (defaults.Key != Keys.None)
                {
                    binding.Keyboard.Add(defaults.Key);
                }

                if (defaults.Keys != null)
                {
                    binding.Add(defaults.Keys.Where((Keys k) => k != Keys.None).ToArray());
                }
            }

            ((IOriginalGameInputProcessEnvironment)sourceEngine).InputSource.Initialize();
            Reload(Selection);
        }
    }
}
