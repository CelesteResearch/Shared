using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class EmbeddedKeyboardDevice : ISourceKeyboardDevice
    {
        private readonly byte[] keys = new byte[256];
        private readonly Func<int, int> translateScancode;
        public bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public EmbeddedKeyboardDevice(Func<int, int> translateScancode)
        {
            this.translateScancode = translateScancode;
        }

        public void Advance(int[] pressedKeys, bool focused)
        {
            Array.Clear(keys, 0, keys.Length);
            if (!focused) return;
            foreach (var key in pressedKeys)
                if (key > 0 && key < keys.Length)
                    keys[key] = 0x80;
        }

        public void CopyKeysTo(List<SourceKeys> destination)
        {
            destination.Clear();
            for (var key = 1; key < keys.Length; key++)
                if (keys[key] != 0)
                    destination.Add((SourceKeys)key);
        }

        public bool ReadWin32KeyboardState(Span<byte> destination)
        {
            if (destination.Length < keys.Length)
                throw new ArgumentException("Expected 256 key bytes.", nameof(destination));
            destination.Clear();
            keys.AsSpan().CopyTo(destination);
            destination[16] |= (byte)(keys[160] | keys[161]);
            destination[17] |= (byte)(keys[162] | keys[163]);
            destination[18] |= (byte)(keys[164] | keys[165]);
            return true;
        }

        public string GetEnvironmentVariable(string name) => Environment.GetEnvironmentVariable(name)!;
        public SourceKeys GetKeyFromScancode(SourceKeys scancode) => (SourceKeys)translateScancode((int)scancode);
    }
}
