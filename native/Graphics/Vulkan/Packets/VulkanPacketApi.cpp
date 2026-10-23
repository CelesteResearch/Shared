#include "VulkanPacketApi.h"
#include "VulkanSubmissionQueue.h"
#include "VulkanDevicePackets.h"
#include "VulkanApiErrors.h"
#include <stdexcept>
#include <string>

void VulkanBeginPacket(CelesteGraphicsDevice* device, CelesteGraphicsPacket** result)
{
    if (result)
        *result = nullptr;
    if (!device || !result)
        throw std::invalid_argument("BeginPacket requires device and output");
    *result = new CelesteGraphicsPacket(*device);
}
void VulkanSubmitPacket(CelesteGraphicsPacket* packet, CelesteGraphicsSubmission** result)
{
    if (result)
        *result = nullptr;
    if (!packet || !result)
        throw std::invalid_argument("Submit requires packet and output");
    packet->RequireOpen();
    auto observer = std::make_unique<CelesteGraphicsSubmission>();
    observer->completion = packet->Completion();
    packet->Prepare();
    VulkanSubmissionQueue* queueOwner = nullptr;
    size_t slot = SIZE_MAX;
    try
    {
        queueOwner = &packet->Owner().Submissions();
        auto& queue = *queueOwner;
        slot = queue.Begin();
        Celeste::Graphics::Vulkan::ImageRecording images(queue.GetCommandBuffer(slot), packet->storage->images.data(),
                                                         packet->storage->images.size());
        Celeste::Graphics::Vulkan::DepthStencilRecording depth(
            queue.GetCommandBuffer(slot), packet->storage->depths.data(), packet->storage->depths.size());
        VulkanPacketRecordContext context{queue.GetCommandBuffer(slot), images, depth};
        // The retained bundle allocation is also completed before first vkCmd.
        std::vector<std::shared_ptr<void>> retained{packet->storage};
        packet->Record(context);
        packet->Completion()->submission = queue.SubmitMany(
            slot, std::move(retained), static_cast<uint32_t>(packet->storage->waitSemaphores.size()),
            packet->storage->waitSemaphores.data(), packet->storage->waitStages.data(),
            static_cast<uint32_t>(packet->storage->signalSemaphores.size()), packet->storage->signalSemaphores.data());
        packet->Completion()->queued = true;
        images.Commit();
        depth.Commit();
        packet->Commit();
        *result = observer.release();
    }
    catch (...)
    {
        if (queueOwner && slot != SIZE_MAX)
            queueOwner->Abandon(slot);
        packet->phase = CelesteGraphicsPacket::Phase::Open;
        throw;
    }
}
void VulkanReleasePacket(CelesteGraphicsPacket* packet) noexcept
{
    if (packet && packet->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
        delete packet;
}
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanRetainPacket(CelesteGraphicsPacket* packet)
{
    return VulkanInvoke([&] {
        if (!packet)
            throw std::invalid_argument("Packet retention requires a live packet loan");
        packet->references.fetch_add(1, std::memory_order_relaxed);
    });
}
int32_t VulkanSubmissionCompletion(CelesteGraphicsSubmission* submission)
{
    if (!submission)
        throw std::invalid_argument("Submission is null");
    const VkResult result = submission->completion->Poll();
    if (result == VK_NOT_READY)
        return 0;
    if (result != VK_SUCCESS)
        throw std::runtime_error("Vulkan submission failed: VkResult " + std::to_string(result));
    return 1;
}
void VulkanWaitSubmission(CelesteGraphicsSubmission* submission)
{
    if (!submission)
        throw std::invalid_argument("Submission is null");
    const VkResult result = submission->completion->Wait();
    if (result != VK_SUCCESS)
        throw std::runtime_error("Vulkan submission wait failed: VkResult " + std::to_string(result));
}
void VulkanReleaseSubmission(CelesteGraphicsSubmission* submission) noexcept
{
    delete submission;
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanRecordHostPacket(CelesteGraphicsPacket* packet,
                                                                       const CelesteVulkanHostRecording* recording)
{
    return VulkanInvoke([&] {
        if (!packet || !recording || !recording->commandBuffer)
            throw std::invalid_argument("Host recording requires packet and command buffer");
        packet->RequireOpen();
        if (!packet->storage->waitSemaphores.empty() || !packet->storage->signalSemaphores.empty())
            throw std::invalid_argument("Host command-buffer recording delegates semaphores to the host submission");
        auto& owner = packet->Owner().Packets();
        if ((owner.hasCompletedHost && recording->submissionSerial <= owner.completedHostSerial) ||
            (owner.hasRecordedHost && recording->submissionSerial < owner.lastHostSerial))
            throw std::invalid_argument("Host recording serial must follow retired work and be monotonic");
        packet->Prepare();
        try
        {
            Celeste::Graphics::Vulkan::ImageRecording images(recording->commandBuffer, packet->storage->images.data(),
                                                             packet->storage->images.size());
            Celeste::Graphics::Vulkan::DepthStencilRecording depth(
                recording->commandBuffer, packet->storage->depths.data(), packet->storage->depths.size());
            VulkanPacketRecordContext context{recording->commandBuffer, images, depth};
            // Retention storage is allocated before emitting any host command.
            owner.hostSubmissions.push_back({recording->submissionSerial, packet->storage});
            packet->Record(context);
            packet->Completion()->queued = true;
            images.Commit();
            depth.Commit();
            packet->Commit();
            owner.lastHostSerial = recording->submissionSerial;
            owner.hasRecordedHost = true;
        }
        catch (...)
        {
            packet->phase = CelesteGraphicsPacket::Phase::Open;
            throw;
        }
    });
}
extern "C" void CELESTE_GRAPHICS_CALL CelesteVulkanRetireHostSubmissions(CelesteGraphicsDevice* device, uint64_t serial)
{
    VulkanInvoke([&] {
        if (!device)
            throw std::invalid_argument("Host retirement device is null");
        if (device->packetState)
            device->packetState->Retire(serial);
    });
}
