using System;
using System.Numerics;

namespace Celeste.Input
{
    public sealed class InputContext
    {
        public float DeltaTime = 1f / 60f;
        public bool Disabled;
    }
}
