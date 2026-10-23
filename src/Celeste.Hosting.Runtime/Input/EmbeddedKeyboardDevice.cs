using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class EmbeddedKeyboardDevice : ISourceKeyboardDevice
    {
        private readonly byte[] _keys = new byte[256];
        private readonly Func<int, int> _translateScancode;
        public bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public EmbeddedKeyboardDevice(Func<int, int> translateScancode)
        {
            _translateScancode = translateScancode;
        }

        public void Advance(int[] pressedKeys, bool focused)
        {
            Array.Clear(_keys, 0, _keys.Length);
            if (!focused) return;
            foreach (var key in pressedKeys)
                if (key > 0 && key < _keys.Length)
                    _keys[key] = 0x80;
        }

        public void CopyKeysTo(List<SourceKeys> destination)
        {
            destination.Clear();
            for (var key = 1; key < _keys.Length; key++)
                if (_keys[key] != 0)
                    destination.Add((SourceKeys)key);
        }

        public bool ReadWin32KeyboardState(Span<byte> destination)
        {
            if (destination.Length < _keys.Length)
                throw new ArgumentException("Expected 256 key bytes.", nameof(destination));
            destination.Clear();
            _keys.AsSpan().CopyTo(destination);
            destination[16] |= (byte)(_keys[160] | _keys[161]);
            destination[17] |= (byte)(_keys[162] | _keys[163]);
            destination[18] |= (byte)(_keys[164] | _keys[165]);
            return true;
        }

        public string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name)!;
        }

        public SourceKeys GetKeyFromScancode(SourceKeys scancode)
        {
            return (SourceKeys)_translateScancode((int)scancode);
        }
    }
}
