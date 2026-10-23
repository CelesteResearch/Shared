using System;

namespace Celeste.Hosting.Runtime
{
    internal sealed class BackgroundInputFrame
    {
        public BackgroundInputFrame? Next;
        public int[] Keys = [];
        public int MouseX;
        public int MouseY;
        public uint Buttons;
        public int Wheel;
        public bool Focused;
        public long Updates;

        public bool Matches(int[] keys, int x, int y, uint buttons, int wheel, bool focused)
        {
            if (Wheel != 0 || wheel != 0 || MouseX != x || MouseY != y || Buttons != buttons || Focused != focused ||
                Keys.Length != keys.Length)
                return false;
            for (var i = 0; i < keys.Length; i++)
                if (Keys[i] != keys[i])
                    return false;
            return true;
        }

        public void Set(int[] keys, int x, int y, uint buttons, int wheel, bool focused)
        {
            if (Keys.Length != keys.Length) Keys = new int[keys.Length];
            Array.Copy(keys, Keys, keys.Length);
            MouseX = x;
            MouseY = y;
            Buttons = buttons;
            Wheel = wheel;
            Focused = focused;
            Updates = 1;
        }
    }
}
