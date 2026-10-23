#pragma once
struct VulkanPacketRecordContext;
#include <cstddef>
struct CelesteGraphicsPacket;
using VulkanPacketPrepare = void (*)(CelesteGraphicsPacket&, void*);
using VulkanPacketRecord = void (*)(CelesteGraphicsPacket&, const void*, VulkanPacketRecordContext&) noexcept;
using VulkanPacketCommit = void (*)(CelesteGraphicsPacket&, const void*) noexcept;
struct VulkanPacketCommand final
{
    size_t offset;
    VulkanPacketPrepare prepare;
    VulkanPacketRecord record;
    VulkanPacketCommit commit;
};
