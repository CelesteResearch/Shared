using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Shaders
{
    // Numeric values match the existing source vertex usage/format declarations.
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SpirvVertexAttribute(int usage, int format, int usageIndex)
    {
        public readonly int Usage = usage;
        public readonly int Format = format;
        public readonly int UsageIndex = usageIndex;
    }
}
