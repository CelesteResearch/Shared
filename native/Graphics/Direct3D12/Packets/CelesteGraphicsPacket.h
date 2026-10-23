#pragma once
#include "CelesteGraphicsDevice.h"
#include "CelesteGraphicsSubmission.h"
#include "Direct3D12PacketStorage.h"
#include "Direct3D12PacketRecordContext.h"
#include <atomic>
#include <cstring>
#include <stdexcept>
#include <type_traits>
namespace Celeste::Graphics::Direct3D12
{
    class BindingBatch;
}
struct Direct3D12DrawState;
struct Direct3D12DrawArena;
struct CelesteGraphicsPacket
{
    std::shared_ptr<Direct3D12DrawArena> drawArena;
    std::shared_ptr<Direct3D12DrawState> drawState;
    std::shared_ptr<Celeste::Graphics::Direct3D12::BindingBatch> drawBindings;
    enum class Phase
    {
        Open,
        Preparing,
        Prepared,
        Submitted,
        Canceled
    };
    CelesteGraphicsDevice& device;
    std::shared_ptr<Direct3D12PacketStorage> storage = std::make_shared<Direct3D12PacketStorage>();
    std::atomic<uint32_t> references{1};
    Phase phase = Phase::Open;
    std::unique_ptr<CelesteGraphicsSubmission> hostSubmission;
    ID3D12GraphicsCommandList* hostCommands = nullptr;
    explicit CelesteGraphicsPacket(CelesteGraphicsDevice& owner) : device(owner)
    {
    }
    ~CelesteGraphicsPacket()
    {
        if (phase != Phase::Submitted)
            storage->completion->Cancel();
    }
    const std::shared_ptr<Direct3D12PacketCompletion>& Completion() const
    {
        return storage->completion;
    }
    CelesteGraphicsDevice& Owner() const
    {
        return device;
    }
    void RequireOpen() const;
    size_t StoreBytes(const void*, size_t, size_t alignment = alignof(std::max_align_t));
    void* GetBytes(size_t offset)
    {
        return storage->bytes.data() + offset;
    }
    const void* GetBytes(size_t offset) const
    {
        return storage->bytes.data() + offset;
    }
    template <class T> uint32_t Retain(std::shared_ptr<T> value)
    {
        if (phase != Phase::Open && phase != Phase::Preparing)
            throw std::logic_error("Packet retention is closed");
        if (storage->resources.size() >= UINT32_MAX)
            throw std::length_error("Packet resource limit");
        auto index = static_cast<uint32_t>(storage->resources.size());
        storage->resources.push_back(std::move(value));
        return index;
    }
    template <class T> T& Resource(uint32_t index) const
    {
        return *static_cast<T*>(storage->resources[index].get());
    }
    template <class T>
    void AddCommand(const T& payload, Direct3D12PacketPrepare prepare, Direct3D12PacketRecord record,
                    Direct3D12PacketCommit commit = nullptr)
    {
        static_assert(std::is_trivially_copyable_v<T>);
        RequireOpen();
        auto offset = StoreBytes(&payload, sizeof(T), alignof(T));
        storage->commands.push_back({offset, prepare, record, commit});
    }
    void RegisterResource(std::shared_ptr<Celeste::Graphics::Direct3D12::GpuResource> resource);
    std::unique_ptr<Celeste::Graphics::Direct3D12::CommandLease> Prepare();
    void Commit() noexcept;
};
