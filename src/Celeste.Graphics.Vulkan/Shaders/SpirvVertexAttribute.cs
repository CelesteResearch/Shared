using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Shaders
{
    // Numeric values match the existing source vertex usage/format declarations.
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SpirvVertexAttribute
    {
        public readonly int Usage;
        public readonly int Format;
        public readonly int UsageIndex;

        public SpirvVertexAttribute(int usage, int format, int usageIndex)
        {
            Usage = usage;
            Format = format;
            UsageIndex = usageIndex;
        }
    }
}
