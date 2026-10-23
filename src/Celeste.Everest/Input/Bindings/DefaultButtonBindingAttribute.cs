using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Everest.Input.Bindings
{
    /// <summary>
    ///       Sets the default <see cref="F:Celeste.Mod.DefaultButtonBindingAttribute.Buttons" /> and <see cref="F:Celeste.Mod.DefaultButtonBindingAttribute.Keys" /> of a <see cref="T:Celeste.Mod.ButtonBinding" /> setting.
    ///       <br /><see href="https://github.com/EverestAPI/Resources/wiki/Mod-Settings#DefaultButtonBinding">Read More</see></summary>
    public class DefaultButtonBindingAttribute : Attribute
    {
        /// <summary>
        ///       The default Button binding.
        ///       </summary>
        public Buttons Button;

        /// <summary>
        ///       The default Key binding.
        ///       </summary>
        public Keys Key;

        /// <summary>
        ///       The default Buttons binding.
        ///       </summary>
        public Buttons[] Buttons;

        /// <summary>
        ///       The default Keys binding.
        ///       </summary>
        public Keys[] Keys;

        /// <summary>
        ///       Whether the default Button should always be bound.
        ///       </summary>
        [Obsolete("This is no longer respected by the new input system.")]
        public bool ForceDefaultButton;

        /// <summary>
        ///       Whether the default Key should always be bound.
        ///       </summary>
        [Obsolete("This is no longer respected by the new input system.")]
        public bool ForceDefaultKey;

        /// <summary>
        ///       Sets the default <see cref="F:Celeste.Mod.DefaultButtonBindingAttribute.Buttons" /> and <see cref="F:Celeste.Mod.DefaultButtonBindingAttribute.Keys" /> of a <see cref="T:Celeste.Mod.ButtonBinding" /> setting.
        ///       </summary>
        /// <param name="button">The default Button binding.</param>
        /// <param name="key">The default Key binding.</param>
        public DefaultButtonBindingAttribute(Buttons button, Keys key)
        {
            Button = button;
            Key = key;
        }

        /// <summary>
        ///       Sets the default <see cref="F:Celeste.Mod.DefaultButtonBindingAttribute.Buttons" /> and <see cref="F:Celeste.Mod.DefaultButtonBindingAttribute.Keys" /> of a <see cref="T:Celeste.Mod.ButtonBinding" /> setting.
        ///       </summary>
        /// <param name="buttons">The default Buttons binding.</param>
        /// <param name="keys">The default Keys binding.</param>
        public DefaultButtonBindingAttribute(Buttons[] buttons, Keys[] keys)
        {
            Buttons = buttons;
            Keys = keys;
        }
    }
}
