#include "CelesteGraphicsPacket.h"
#include <algorithm>
#include <limits>

CelesteGraphicsPacket::CelesteGraphicsPacket(CelesteGraphicsDevice& owner)
    : device(owner), storage(std::make_shared<VulkanPacketStorage>())
{
    storage->completion = std::make_shared<VulkanPacketCompletion>(owner);
}
CelesteGraphicsPacket::~CelesteGraphicsPacket()
{
    if (!storage->completion->queued)
    {
        storage->completion->hostResult = VK_ERROR_UNKNOWN;
        storage->completion->queued = true;
    }
}
void CelesteGraphicsPacket::RequireOpen() const
{
    if (phase != Phase::Open)
        throw std::logic_error("Vulkan packet is sealed");
}
size_t CelesteGraphicsPacket::StoreBytes(const void* bytes, size_t count, size_t alignment)
{
    RequireOpen();
    if (!alignment || (alignment & (alignment - 1)) || alignment > alignof(std::max_align_t))
        throw std::invalid_argument("Unsupported Vulkan packet payload alignment");
    if (count && !bytes)
        throw std::invalid_argument("Vulkan packet bytes are null");
    const size_t previous = storage->bytes.size();
    if (previous > std::numeric_limits<size_t>::max() - (alignment - 1))
        throw std::length_error("Vulkan packet size overflow");
    const size_t offset = (previous + alignment - 1) & ~(alignment - 1);
    if (count > std::numeric_limits<size_t>::max() - offset)
        throw std::length_error("Vulkan packet size overflow");
    storage->bytes.resize(offset + count);
    if (count)
        std::memcpy(storage->bytes.data() + offset, bytes, count);
    return offset;
}
void CelesteGraphicsPacket::RegisterImage(Celeste::Graphics::Vulkan::TextureImage& image)
{
    if (phase != Phase::Open && phase != Phase::Preparing)
        throw std::logic_error("Vulkan image registration is closed");
    if (std::find(storage->images.begin(), storage->images.end(), &image) == storage->images.end())
        storage->images.push_back(&image);
}
void CelesteGraphicsPacket::Prepare()
{
    RequireOpen();
    phase = Phase::Preparing;
    try
    {
        for (auto& command : storage->commands)
            if (command.prepare)
                command.prepare(*this, GetBytes(command.offset));
        phase = Phase::Prepared;
    }
    catch (...)
    {
        phase = Phase::Open;
        throw;
    }
}
void CelesteGraphicsPacket::Record(VulkanPacketRecordContext& context) noexcept
{
    for (auto& command : storage->commands)
        if (command.record)
            command.record(*this, GetBytes(command.offset), context);
}
void CelesteGraphicsPacket::Commit() noexcept
{
    for (auto& command : storage->commands)
        if (command.commit)
            command.commit(*this, GetBytes(command.offset));
    phase = Phase::Submitted;
}

void CelesteGraphicsPacket::RegisterDepth(Celeste::Graphics::Vulkan::DepthStencilAttachment& depth)
{
    if (phase != Phase::Open && phase != Phase::Preparing)
        throw std::logic_error("Vulkan depth registration is closed");
    if (std::find(storage->depths.begin(), storage->depths.end(), &depth) == storage->depths.end())
        storage->depths.push_back(&depth);
}
