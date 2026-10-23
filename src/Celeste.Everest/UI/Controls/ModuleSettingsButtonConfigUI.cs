using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Input.Bindings;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Settings.Metadata;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Menus.Options;
using Binding = Celeste.Input.Bindings.SourceInputBinding;
using ButtonBinding = Celeste.Everest.Input.Bindings.EverestButtonBinding;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Everest.UI.Controls
{
    public class ModuleSettingsButtonConfigUI : EverestButtonConfigPresentation
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

        protected List<ButtonBindingEntry> Bindings = [];

        public ModuleSettingsButtonConfigUI(SourceEverestModule module, ISourceEngineContext engine,
            MenuOptionsPresentation menuOptions) : base(engine, menuOptions)
        {
            sourceEngine = engine;
            var moduleSettingsButtonConfigUi = this;
            All.Add(Buttons.Back);
            All.Add(Buttons.BigButton);
            All.Add(Buttons.RightStick);
            All.Add(Buttons.LeftStick);
            Module = module;
            object scene = sourceEngine.Frame.Scenes.CurrentScene;
            var level = scene as Level;
            if (level != null)
            {
                bool? oldAllowHudHide = null;
                OnUpdate = delegate
                {
                    if (!oldAllowHudHide.HasValue)
                    {
                        oldAllowHudHide = level.AllowHudHide;
                        level.AllowHudHide = false;
                        moduleSettingsButtonConfigUi.OnClose = (Action)Delegate.Combine(
                            moduleSettingsButtonConfigUi.OnClose,
                            (Action)delegate { level.AllowHudHide = oldAllowHudHide.Value; });
                    }
                };
            }

            Reload(2);
        }

        public override void Reload(int index = -1)
        {
            if (Module == null) return;

            Clear();
            Add(new Header(Text.CleanDialog("BTN_CONFIG_TITLE")));
            Add(new InputMappingInfoPresentation(sourceEngine, true));
            Bindings.Clear();
            object settings = Module._Settings;
            var text = Module.SettingsType.Name.ToLowerInvariant();
            if (text.EndsWith("settings")) text = text.Substring(0, text.Length - 8);

            var text2 = "modoptions_" + text + "_";
            var properties = Module.SettingsType.GetProperties();
            foreach (var propertyInfo in properties)
            {
                SettingInGameAttribute customAttribute;
                if (((customAttribute = propertyInfo.GetCustomAttribute<SettingInGameAttribute>()) == null ||
                     customAttribute.InGame == sourceEngine.Frame.Scenes.CurrentScene is Level) &&
                    propertyInfo.GetCustomAttribute<SettingIgnoreAttribute>() == null && propertyInfo.CanRead &&
                    propertyInfo.CanWrite && typeof(ButtonBinding).IsAssignableFrom(propertyInfo.PropertyType) &&
                    propertyInfo.GetValue(settings) is ButtonBinding buttonBinding)
                {
                    _ = Bindings.Count;
                    var input = propertyInfo.GetCustomAttribute<SettingNameAttribute>()?.Name ??
                                text2 + propertyInfo.Name.ToLowerInvariant();
                    input = EverestModuleDialogText.CleanOrNull(sourceEngine, input) ??
                            EverestStringSource.SpacedPascalCase(
                                propertyInfo.Name.ToLowerInvariant().StartsWith("button")
                                    ? propertyInfo.Name.Substring(6)
                                    : propertyInfo.Name);
                    var customAttribute2 =
                        propertyInfo.GetCustomAttribute<DefaultButtonBindingAttribute>();
                    Bindings.Add(new(buttonBinding, customAttribute2));
                    var text3 = propertyInfo.GetCustomAttribute<SettingSubHeaderAttribute>()?.SubHeader;
                    if (text3 != null)
                        Add(new SubHeader(EverestModuleDialogText.CleanOrNull(sourceEngine, text3) ?? text3));

                    AddMapForceLabel(input, buttonBinding.Binding);
                }
            }

            Add(new SubHeader(""));
            Add(new Button(Text.CleanDialog("KEY_CONFIG_RESET"))
            {
                IncludeWidthInMeasurement = false,
                AlwaysCenter = true,
                OnPressed = delegate { ResetPressed(); },
            });
            if (index >= 0) Selection = index;
        }

        public override void Reset()
        {
            foreach (var binding2 in Bindings)
            {
                Binding binding = binding2.Binding.Binding;
                binding.Controller.Clear();
                var defaults = binding2.Defaults;
                if (defaults == null) continue;

                if (defaults.Button != 0) binding.Controller.Add(defaults.Button);

                if (defaults.Buttons != null) binding.Add([.. defaults.Buttons.Where(b => b != 0)]);
            }

            ((IOriginalGameInputProcessEnvironment)sourceEngine).InputSource.Initialize();
            Reload(Selection);
        }
    }
}
