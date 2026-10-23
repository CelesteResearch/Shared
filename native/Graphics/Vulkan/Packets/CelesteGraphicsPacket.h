#pragma once
#include "CelesteGraphicsDevice.h"
#include "VulkanPacketStorage.h"
#include "CelesteGraphicsSubmission.h"
#include "ImageRecording.h"
#include "VulkanPacketRecordContext.h"
#include <cstddef>
#include <cstdint>
#include <cstring>
#include <memory>
#include <stdexcept>
#include <type_traits>
#include <vector>

class VulkanDrawState;
struct CelesteGraphicsPacket final
{
    enum class Phase
    {
        Open,
        Preparing,
        Prepared,
        Submitted
    };
    CelesteGraphicsDevice& device;
    std::shared_ptr<VulkanPacketStorage> storage;
    std::shared_ptr<VulkanDrawState> drawState;
    Phase phase = Phase::Open;
    std::atomic<uint32_t> references{1};
    explicit CelesteGraphicsPacket(CelesteGraphicsDevice& owner);
    ~CelesteGraphicsPacket();
    CelesteGraphicsDevice& Owner()
    {
        return device;
    }
    VulkanDrawState& DrawState();
    void RequireOpen() const;
    size_t StoreBytes(const void* bytes, size_t count, size_t alignment = alignof(std::max_align_t));
    const void* GetBytes(size_t offset) const
    {
        return storage->bytes.data() + offset;
    }
    void* GetBytes(size_t offset)
    {
        return storage->bytes.data() + offset;
    }
    template <class T> uint32_t Retain(std::shared_ptr<T> resource)
    {
        if (phase != Phase::Open && phase != Phase::Preparing)
            throw std::logic_error("Vulkan packet resource retention is closed");
        const size_t index = storage->resources.size();
        if (index >= UINT32_MAX)
            throw std::length_error("Vulkan packet resource count exceeds ABI range");
        storage->resources.push_back(std::move(resource));
        return static_cast<uint32_t>(index);
    }
    template <class T> T& Resource(uint32_t index) const
    {
        return *static_cast<T*>(storage->resources[index].get());
    }
    template <class T>
    void AddCommand(const T& payload, VulkanPacketPrepare prepare, VulkanPacketRecord record,
                    VulkanPacketCommit commit = nullptr)
    {
        static_assert(std::is_trivially_copyable_v<T>, "Command payloads use resource indices, not owning pointers");
        const size_t offset = StoreBytes(&payload, sizeof(T), alignof(T));
        storage->commands.push_back({offset, prepare, record, commit});
    }
    void RegisterImage(Celeste::Graphics::Vulkan::TextureImage& image);
    void RegisterDepth(Celeste::Graphics::Vulkan::DepthStencilAttachment& depth);
    const std::shared_ptr<VulkanPacketCompletion>& Completion() const
    {
        return storage->completion;
    }
    void Prepare();
    void Record(VulkanPacketRecordContext& context) noexcept;
    void Commit() noexcept;
};
