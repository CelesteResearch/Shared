using System.Collections.Generic;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Input.Bindings
{
    public sealed class SourceFnaTextInputBindings
    {
        public readonly char[] TextInputCharacters;
        public readonly Dictionary<SourceKeys, int> TextInputBindings;

        public SourceFnaTextInputBindings()
        {
            TextInputCharacters = ['\u0002', '\u0003', '\b', '\t', '\r', '\u007f', '\u0016'];
            TextInputBindings = new()
            {
                { SourceKeys.Home, 0 }, { SourceKeys.End, 1 },
                { SourceKeys.Back, 2 }, { SourceKeys.Tab, 3 },
                { SourceKeys.Enter, 4 }, { SourceKeys.Delete, 5 },
            };
        }
    }
}
