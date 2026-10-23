#include "CelesteGraphicsPacket.h"
#include <limits>
using namespace Celeste::Graphics::Direct3D12;
void CelesteGraphicsPacket::RequireOpen() const
{
    if (phase != Phase::Open)
        throw std::logic_error("Packet is not open");
}
size_t CelesteGraphicsPacket::StoreBytes(const void* source, size_t count, size_t alignment)
{
    if (phase != Phase::Open && phase != Phase::Preparing)
        throw std::logic_error("Packet bytes are sealed");
    if (!alignment || (alignment & (alignment - 1)) || (count && !source))
        throw std::invalid_argument("Invalid packet bytes");
    if (storage->bytes.size() > SIZE_MAX - (alignment - 1))
        throw std::length_error("Packet alignment overflow");
    const size_t offset = (storage->bytes.size() + alignment - 1) & ~(alignment - 1);
    if (count > SIZE_MAX - offset)
        throw std::length_error("Packet byte overflow");
    storage->bytes.resize(offset + count);
    if (count)
        std::memcpy(storage->bytes.data() + offset, source, count);
    return offset;
}
void CelesteGraphicsPacket::RegisterResource(std::shared_ptr<GpuResource> resource)
{
    if (phase != Phase::Open && phase != Phase::Preparing)
        throw std::logic_error("Packet resource tracking sealed");
    if (!resource || resource->context != device.context)
        throw std::invalid_argument("Resource belongs to another device");
    for (const auto& existing : storage->tracked)
        if (existing == resource)
            return;
    storage->tracked.push_back(std::move(resource));
}
std::unique_ptr<CommandLease> CelesteGraphicsPacket::Prepare()
{
    RequireOpen();
    phase = Phase::Preparing;
    for (const auto& command : storage->commands)
        if (command.prepare)
            command.prepare(*this, GetBytes(command.offset));
    auto lease = device.submissions->Begin();
    storage->states = std::make_shared<ResourceStateTransaction>(*lease, storage->tracked);
    lease->Retain(storage);
    Direct3D12PacketRecordContext context{*lease, *storage->states};
    for (const auto& command : storage->commands)
        if (command.record)
            command.record(*this, GetBytes(command.offset), context);
    phase = Phase::Prepared;
    return lease;
}
void CelesteGraphicsPacket::Commit() noexcept
{
    storage->states->Commit();
    for (const auto& command : storage->commands)
        if (command.commit)
            command.commit(*this, GetBytes(command.offset));
    phase = Phase::Submitted;
}
