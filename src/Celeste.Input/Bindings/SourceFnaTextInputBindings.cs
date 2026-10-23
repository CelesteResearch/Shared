using Celeste.Input.Devices.Keyboard;
using System.Collections.Generic;

namespace Celeste.Input.Bindings
{
    public sealed class SourceFnaTextInputBindings
    {
        public readonly char[] TextInputCharacters;
        public readonly Dictionary<SourceKeys, int> TextInputBindings;

        public SourceFnaTextInputBindings()
        {
            TextInputCharacters = new char[7] { '\u0002', '\u0003', '\b', '\t', '\r', '\u007f', '\u0016' };
            TextInputBindings = new Dictionary<SourceKeys, int>
            {
                { SourceKeys.Home, 0 }, { SourceKeys.End, 1 },
                { SourceKeys.Back, 2 }, { SourceKeys.Tab, 3 },
                { SourceKeys.Enter, 4 }, { SourceKeys.Delete, 5 }
            };
        }
    }
}
