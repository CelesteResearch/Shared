using System;

namespace Celeste.Graphics.Vulkan.Interop
{
    [Flags]
    public enum VulkanPortabilityFeatures : uint
    {
        None = 0,
        Subset = 1,
        ImageViewSwizzle = 2,
        SamplerMipLodBias = 4,
        SeparateStencilMaskReference = 8,
        ConstantAlphaColorBlendFactors = 16,
        VertexAttributeAccessBeyondStride = 32,
    }
}
