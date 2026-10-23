#pragma once
#include "SourceSamplerBinding.h"
#include "TransferBuffer.h"
#include "VertexStreamBinding.h"
#include "DepthStencilAttachment.h"
#include "ColorTargetBinding.h"
#include <array>
#include <vector>
namespace Celeste::Graphics::Vulkan
{
    struct DrawLogicalState
    {
        std::shared_ptr<TextureImage> target;
        uint32_t targetLevel = 0, targetLayer = 0;
        uint32_t colorTargetCount = 1;
        std::array<ColorTargetBinding, 3> additionalTargets{};
        std::shared_ptr<DepthStencilAttachment> depthAttachment;
        std::shared_ptr<TransferBuffer> vertices;
        uint32_t stride = 0;
        VkDeviceSize vertexOffset = 0;
        std::vector<SourceVertexElement> elements;
        std::vector<uint32_t> elementBindings;
        std::vector<VertexStreamBinding> streams;
        std::vector<VkBuffer> vertexBuffers;
        std::vector<VkDeviceSize> vertexOffsets;
        std::array<std::array<SourceSamplerBinding, 16>, 2> samplers;
        SourceNativeBlendState blend{};
        SourceNativeDepthStencilState depth{};
        SourceNativeRasterizerState raster{};
        SourceCameraViewport viewport{};
        CelesteGraphicsRect scissor{};
        DrawLogicalState();
    };
}
