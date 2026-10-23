using System.Linq;
using System.Reflection;
using Celeste.Everest.Input;
using Celeste.Everest.Input.Bindings;
using Celeste.Input.Bindings;
using Celeste.Input.Gameplay;
using Celeste.Input.Runtime;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;

namespace Celeste.Everest.Modules.Runtime
{
    public abstract partial class SourceEverestModule
    {
        public virtual void OnInputInitialize()
        {
            if (SettingsType == null) return;

            object settings = _Settings;
            if (settings == null) return;

            var properties = SettingsType.GetProperties();
            foreach (var propertyInfo in properties)
                if (propertyInfo.CanRead && typeof(EverestButtonBinding).IsAssignableFrom(propertyInfo.PropertyType))
                    InitializeButtonBinding(settings, propertyInfo);
        }

        public virtual void OnInputDeregister()
        {
            if (SettingsType == null) return;

            object settings = _Settings;
            var properties = SettingsType.GetProperties();
            foreach (var propertyInfo in properties)
                if (propertyInfo.CanRead && typeof(EverestButtonBinding).IsAssignableFrom(propertyInfo.PropertyType) &&
                    propertyInfo.GetValue(settings) is EverestButtonBinding buttonBinding)
                    buttonBinding.Button?.Deregister();
        }

        private void InitializeButtonBinding(object settings, PropertyInfo prop)
        {
            var buttonBinding = prop.GetValue(settings) as EverestButtonBinding;
            if (buttonBinding == null)
            {
                buttonBinding = new();
                var
                    customAttribute = prop.GetCustomAttribute<DefaultButtonBindingAttribute>();
                if (customAttribute != null)
                {
                    if (customAttribute.Button != 0) buttonBinding.Binding.Add(customAttribute.Button);

                    if (customAttribute.Key != Keys.None) buttonBinding.Binding.Add(customAttribute.Key);

                    if (customAttribute.Buttons != null)
                        buttonBinding.Binding.Add([
                            .. customAttribute.Buttons.Where(b => b != 0),
                        ]);

                    if (customAttribute.Keys != null)
                        buttonBinding.Binding.Add([.. customAttribute.Keys.Where(k => k != Keys.None)]);
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
