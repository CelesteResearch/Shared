using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest.Diagnostics.Commands;
using JetBrains.Annotations;
using YamlDotNet.Serialization;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using MouseButtons = Celeste.Everest.Input.SourceEverestMouseData.MouseButtons;
using Binding = Celeste.Everest.Input.InstalledSourceInputBinding;
using VirtualButton = Celeste.Everest.Input.SourceEverestVirtualButton;

namespace Celeste.Everest.Input.Bindings
{
    /// <summary>
    ///     A wrapper class for a custom <see cref="T:Monocle.VirtualButton" />.
    ///     <br />
    ///     Default buttons can be set using <see cref="T:Celeste.Mod.DefaultButtonBindingAttribute" />.
    ///     <br /><see href="https://github.com/EverestAPI/Resources/wiki/Mod-Settings#EverestButtonBinding">Read More</see>
    /// </summary>
    public class EverestButtonBinding : IEverestCommandsKeyBinding
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private Binding _Binding;

        [YamlIgnore] public VirtualButton Button;

        public List<Buttons> Buttons
        {
            get => Binding.Controller;
            set => Binding.Controller = value ?? [];
        }

        public List<Keys> Keys
        {
            get => Binding.Keyboard;
            set => Binding.Keyboard = value ?? [];
        }

        public List<MouseButtons> MouseButtons
        {
            get => Binding.Mouse;
            set => Binding.Mouse = value ?? [];
        }

        [YamlIgnore]
        public Binding Binding
        {
            get => _Binding;
            private set => _Binding = value;
        }

        [YamlIgnore] public bool Check => Button?.Check ?? false;

        [YamlIgnore] public bool Pressed => Button?.Pressed ?? false;

        [YamlIgnore] public bool Released => Button?.Released ?? false;

        [YamlIgnore] public bool Repeating => Button?.Repeating ?? false;

        [YamlIgnore]
        [Obsolete("Please move to Binding ASAP.")]
        public List<SourceEverestVirtualButton.Node> Nodes
        {
            get => Button?.Nodes;
            set
            {
                if (Button != null) Button.Nodes = value;
            }
        }

        [YamlIgnore]
        public float BufferTime
        {
            get => Button?.BufferTime ?? 0f;
            set
            {
                if (Button != null) Button.BufferTime = value;
            }
        }

        [YamlIgnore]
        public Keys? DebugOverridePressed
        {
            get => Button?.DebugOverridePressed;
            set
            {
                if (Button != null) Button.DebugOverridePressed = value;
            }
        }

        public EverestButtonBinding()
            : this(0)
        {
        }

        public EverestButtonBinding(Buttons buttons, params Keys[] keys)
        {
            Init(buttons, keys);
        }

        private void Init(Buttons buttons, params Keys[] keys)
        {
            Binding = new()
            {
                Controller =
                [
                    .. from Buttons b in Enum.GetValues(typeof(Buttons))
                    where (buttons & b) == b
                    select b,
                ],
                Keyboard = [.. keys],
            };
        }

        /// <inheritdoc cref="M:Monocle.VirtualButton.ConsumeBuffer" />
        public void ConsumeBuffer()
        {
            Button?.ConsumeBuffer();
        }

        /// <inheritdoc cref="M:Monocle.VirtualButton.ConsumePress" />
        public void ConsumePress()
        {
            Button?.ConsumePress();
        }

        public void SetRepeat(float repeatTime)
        {
            Button?.SetRepeat(repeatTime);
        }

        public void SetRepeat(float repeatTime, float multiRepeatTime)
        {
            Button?.SetRepeat(repeatTime, multiRepeatTime);
        }

        public static implicit operator bool(EverestButtonBinding binding)
        {
            var button = binding.Button;
            if (button == null) return false;

            return button;
        }
    }
}
