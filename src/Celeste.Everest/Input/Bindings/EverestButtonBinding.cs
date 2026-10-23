using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System;
using System.Collections.Generic;
using System.Linq;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using MouseButtons = Celeste.Everest.Input.SourceEverestMouseData.MouseButtons;
using Binding = Celeste.Everest.Input.InstalledSourceInputBinding;
using VirtualButton = Celeste.Everest.Input.SourceEverestVirtualButton;
using Celeste.Everest.Diagnostics.Commands;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Input.Bindings
{
    /// <summary>
    ///       A wrapper class for a custom <see cref="T:Monocle.VirtualButton" />.
    ///       <br />
    ///       Default buttons can be set using <see cref="T:Celeste.Mod.DefaultButtonBindingAttribute" />.
    ///       <br /><see href="https://github.com/EverestAPI/Resources/wiki/Mod-Settings#EverestButtonBinding">Read More</see></summary>
    public class EverestButtonBinding : IEverestCommandsKeyBinding
    {
        private Binding _Binding;

        [YamlIgnore] public VirtualButton Button;

        public List<Buttons> Buttons
        {
            get { return Binding.Controller; }
            set { Binding.Controller = value ?? new List<Buttons>(); }
        }

        public List<Keys> Keys
        {
            get { return Binding.Keyboard; }
            set { Binding.Keyboard = value ?? new List<Keys>(); }
        }

        public List<MouseButtons> MouseButtons
        {
            get { return Binding.Mouse; }
            set { Binding.Mouse = value ?? new List<MouseButtons>(); }
        }

        [YamlIgnore]
        public Binding Binding
        {
            get { return _Binding; }
            private set { _Binding = value; }
        }

        [YamlIgnore] public bool Check => Button?.Check ?? false;

        [YamlIgnore] public bool Pressed => Button?.Pressed ?? false;

        [YamlIgnore] public bool Released => Button?.Released ?? false;

        [YamlIgnore] public bool Repeating => Button?.Repeating ?? false;

        [YamlIgnore]
        [Obsolete("Please move to Binding ASAP.")]
        public List<VirtualButton.Node> Nodes
        {
            get { return Button?.Nodes; }
            set
            {
                if (Button != null)
                {
                    Button.Nodes = value;
                }
            }
        }

        [YamlIgnore]
        public float BufferTime
        {
            get { return Button?.BufferTime ?? 0f; }
            set
            {
                if (Button != null)
                {
                    Button.BufferTime = value;
                }
            }
        }

        [YamlIgnore]
        public Keys? DebugOverridePressed
        {
            get { return Button?.DebugOverridePressed; }
            set
            {
                if (Button != null)
                {
                    Button.DebugOverridePressed = value;
                }
            }
        }

        public EverestButtonBinding()
            : this((Buttons)0)
        {
        }

        public EverestButtonBinding(Buttons buttons, params Keys[] keys)
        {
            Init(buttons, keys);
        }

        private void Init(Buttons buttons, params Keys[] keys)
        {
            Binding = new Binding
            {
                Controller = (from Buttons b in Enum.GetValues(typeof(Buttons))
                    where (buttons & b) == b
                    select b).ToList(),
                Keyboard = new List<Keys>(keys)
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
            VirtualButton button = binding.Button;
            if (button == null)
            {
                return false;
            }

            return button;
        }
    }
}
