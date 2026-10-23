using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Rendering
{
    // Microsoft.Xna.Framework's Color.Multiply is fixed-point integer arithmetic, not a float multiply:
    //   scale *= 65536f; factor = (uint)scale clamped to [0, 16777215]; channel = (packedByte * factor) >> 16.
    // A float approximation (int)(255f * scale) rounds one 1/255 step up exactly at boundaries: for
    // example Color.White * (1f - 4f/60f) is 237/255 in XNA, not 238/255.
    public static class MachineColors
    {
        public static int Packed(float channel) => (int)Math.Round(channel * 255f, MidpointRounding.ToEven);

        public static int ScaledChannel(int packed, float scale)
        {
            float scaled = scale * 65536f;
            uint factor = scaled < 0f ? 0u : scaled > 16777215f ? 16777215u : (uint)scaled;
            int value = (int)((packed * factor) >> 16);
            return value > 255 ? 255 : value;
        }

        public static Vector4 Scale(Vector4 color, float scale) => new Vector4(
            ScaledChannel(Packed(color.X), scale) / 255f, ScaledChannel(Packed(color.Y), scale) / 255f,
            ScaledChannel(Packed(color.Z), scale) / 255f, ScaledChannel(Packed(color.W), scale) / 255f);
    }
}
