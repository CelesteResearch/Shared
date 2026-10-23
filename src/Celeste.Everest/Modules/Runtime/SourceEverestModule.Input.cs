using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Modules.Persistence;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.IO;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Everest.Input;
using Celeste.Everest.Input.Bindings;
using Celeste.Input.Gameplay;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Everest.Modules.Runtime
{
    public abstract partial class SourceEverestModule
    {
        public virtual void OnInputInitialize()
        {
            if (SettingsType == null)
            {
                return;
            }

            object settings = _Settings;
            if (settings == null)
            {
                return;
            }

            PropertyInfo[] properties = SettingsType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.CanRead && typeof(EverestButtonBinding).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    InitializeButtonBinding(settings, propertyInfo);
                }
            }
        }

        public virtual void OnInputDeregister()
        {
            if (SettingsType == null)
            {
                return;
            }

            object settings = _Settings;
            PropertyInfo[] properties = SettingsType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.CanRead && typeof(EverestButtonBinding).IsAssignableFrom(propertyInfo.PropertyType) &&
                    propertyInfo.GetValue(settings) is EverestButtonBinding buttonBinding)
                {
                    buttonBinding.Button?.Deregister();
                }
            }
        }

        private void InitializeButtonBinding(object settings, PropertyInfo prop)
        {
            EverestButtonBinding buttonBinding = prop.GetValue(settings) as EverestButtonBinding;
            if (buttonBinding == null)
            {
                buttonBinding = new EverestButtonBinding();
                DefaultButtonBindingAttribute
                    customAttribute = prop.GetCustomAttribute<DefaultButtonBindingAttribute>();
                if (customAttribute != null)
                {
                    if (customAttribute.Button != 0)
                    {
                        buttonBinding.Binding.Add(customAttribute.Button);
                    }

                    if (customAttribute.Key != Keys.None)
                    {
                        buttonBinding.Binding.Add(customAttribute.Key);
                    }

                    if (customAttribute.Buttons != null)
                    {
                        buttonBinding.Binding.Add(customAttribute.Buttons.Where((Buttons b) => b != (Buttons)0)
                            .ToArray());
                    }

                    if (customAttribute.Keys != null)
                    {
                        buttonBinding.Binding.Add(customAttribute.Keys.Where((Keys k) => k != Keys.None).ToArray());
                    }
                }

                prop.SetValue(settings, buttonBinding);
            }

            buttonBinding.Button =
                (SourceEverestVirtualButton)((ISourceVirtualInputConstructionEnvironment)SourceEngine)
                .VirtualInputConstruction.CreateButton(
                    ((ISourceMInputEnvironment)SourceEngine).MInput, buttonBinding.Binding,
                    ((ISourceGameInputEnvironment)SourceEngine).Input.Gamepad, 0.08f, 0.2f);
            buttonBinding.Button.AutoConsumeBuffer = true;
        }
    }
}
