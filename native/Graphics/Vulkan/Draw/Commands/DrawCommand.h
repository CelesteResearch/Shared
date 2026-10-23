#pragma once
#include "CelesteGraphicsPacket.h"
#include "CelesteGraphicsSourceTypes.h"
namespace Celeste::Graphics::Vulkan
{
    struct DrawCommand
    {
        uint32_t state, logical, effect, indexBuffer = UINT32_MAX, pipeline = UINT32_MAX;
        SourcePrimitiveType topology;
        uint32_t count, first, instances;
        int32_t baseVertex;
        VkIndexType indexType;
        static void Prepare(CelesteGraphicsPacket&, void*);
        static void Record(CelesteGraphicsPacket&, const void*, VulkanPacketRecordContext&) noexcept;
    };
}
