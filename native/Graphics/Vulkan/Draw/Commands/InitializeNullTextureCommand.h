#pragma once
#include "CelesteGraphicsPacket.h"
namespace Celeste::Graphics::Vulkan
{
    struct InitializeNullTextureCommand
    {
        uint32_t image;
        static void Record(CelesteGraphicsPacket&, const void*, VulkanPacketRecordContext&) noexcept;
    };
}
