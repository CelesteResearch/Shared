using System;

namespace Celeste.Graphics.Vulkan.Shaders
{
    public static class SpirvConstants
    {
        // Effect handle comes from the desktop CpuEffectNative.Instance frontend.
        // Copies into caller-owned mapped/staging memory, with no managed byte-array allocation.
        public static void Copy(IntPtr effect, bool vertex, IntPtr destination, uint capacityBytes)
        {
            SpirvEffectNative.Require(SpirvEffectNative.CelesteSpirvCopyConstants(effect, vertex ? 1 : 0,
                destination, capacityBytes));
        }
    }
}
