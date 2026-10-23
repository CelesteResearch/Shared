using System;

namespace Celeste.Graphics.Rendering.Effects
{
    public struct SourceStateHash(ulong a, ulong b) : IEquatable<SourceStateHash>
    {
        private readonly ulong a = a;

        private readonly ulong b = b;

        public override string ToString()
        {
            return Convert.ToString((long)a, 2).PadLeft(64, '0') + "|" + Convert.ToString((long)b, 2).PadLeft(64, '0');
        }

        bool IEquatable<SourceStateHash>.Equals(SourceStateHash hash)
        {
            if (a == hash.a) return b == hash.b;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            var stateHash = (SourceStateHash)obj;
            if (a == stateHash.a) return b == stateHash.b;

            return false;
        }

        public override int GetHashCode()
        {
            var num = (int)(a ^ (a >> 32));
            var num2 = (int)(b ^ (b >> 32));
            return num + num2;
        }
    }
}
