#include "VulkanPresentationApi.h"
#include "CelesteGraphicsOutput.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsPacket.h"
#include "VulkanDevicePackets.h"
#include "VulkanDrawContext.h"
#include "VulkanDrawApi.h"
#include "VulkanResourceApi.h"
#include <algorithm>
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    struct PresentCommand
    {
        uint32_t source, output;
        CelesteGraphicsRect sourceRect, destinationRect;
        PFN_vkCmdBlitImage blit;
    };
    static CelesteGraphicsRect Rect(const CelesteGraphicsRect* requested, VkExtent2D extent)
    {
        CelesteGraphicsRect result = requested ? *requested
                                               : CelesteGraphicsRect{0, 0, static_cast<int32_t>(extent.width),
                                                                     static_cast<int32_t>(extent.height)};
        if (result.x < 0 || result.y < 0 || result.width <= 0 || result.height <= 0 ||
            uint64_t(result.x) + result.width > extent.width || uint64_t(result.y) + result.height > extent.height)
            throw std::invalid_argument("Presentation rectangle is outside the image");
        return result;
    }
    static void PreparePresent(CelesteGraphicsPacket& packet, void* data)
    {
        auto& command = *static_cast<PresentCommand*>(data);
        auto& output = packet.Resource<VulkanOutputState>(command.output);
        if (output.submitted)
            throw std::logic_error("Output loan was already submitted");
        auto& owner = packet.Owner();
        if (!(owner.Packets()
                  .Format(owner, packet.Resource<TextureImage>(command.source).format.native)
                  .optimalTilingFeatures &
              VK_FORMAT_FEATURE_BLIT_SRC_BIT) ||
            !(owner.Packets().Format(owner, output.info.format).optimalTilingFeatures & VK_FORMAT_FEATURE_BLIT_DST_BIT))
            throw std::runtime_error("Vulkan image format does not support presentation blit");
        command.blit =
            reinterpret_cast<PFN_vkCmdBlitImage>(owner.native.getDeviceProcAddr(owner.native.device, "vkCmdBlitImage"));
        if (!command.blit)
            throw std::runtime_error("Missing vkCmdBlitImage");
    }
    static void RecordPresent(CelesteGraphicsPacket& packet, const void* data,
                              VulkanPacketRecordContext& record) noexcept
    {
        const auto& command = *static_cast<const PresentCommand*>(data);
        auto& source = packet.Resource<TextureImage>(command.source);
        auto& output = packet.Resource<VulkanOutputState>(command.output);
        const auto& info = output.info;
        const uint32_t family = packet.Owner().native.graphicsQueueFamily;
        record.images.Transition(source, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                                 VK_ACCESS_TRANSFER_READ_BIT);
        if (output.texture)
        {
            const VkClearColorValue black{{0, 0, 0, 1}};
            if (command.destinationRect.x != 0 || command.destinationRect.y != 0 ||
                uint32_t(command.destinationRect.width) != info.extent.width ||
                uint32_t(command.destinationRect.height) != info.extent.height)
                record.images.Clear(*output.texture, black, 0, 0);
            record.images.Transition(*output.texture, 0, 0, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                                     VK_PIPELINE_STAGE_TRANSFER_BIT, VK_ACCESS_TRANSFER_WRITE_BIT);
        }
        VkImageMemoryBarrier incoming{VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER};
        incoming.image = info.image;
        incoming.subresourceRange = {VK_IMAGE_ASPECT_COLOR_BIT, 0, 1, 0, 1};
        incoming.oldLayout = info.incomingLayout;
        incoming.newLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
        const bool acquire = info.incomingQueueFamily != VK_QUEUE_FAMILY_IGNORED && info.incomingQueueFamily != family;
        incoming.srcQueueFamilyIndex = acquire ? info.incomingQueueFamily : VK_QUEUE_FAMILY_IGNORED;
        incoming.dstQueueFamilyIndex = acquire ? family : VK_QUEUE_FAMILY_IGNORED;
        incoming.srcAccessMask = acquire || info.incomingLayout == VK_IMAGE_LAYOUT_UNDEFINED ? 0 : info.incomingAccess;
        incoming.dstAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
        if (!output.texture)
            source.context.CmdPipelineBarrier(record.commandBuffer,
                                              acquire || info.incomingLayout == VK_IMAGE_LAYOUT_UNDEFINED
                                                  ? VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT
                                                  : info.incomingStage,
                                              VK_PIPELINE_STAGE_TRANSFER_BIT, 0, 0, nullptr, 0, nullptr, 1, &incoming);
        VkImageBlit blit{};
        blit.srcSubresource = blit.dstSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, 0, 0, 1};
        blit.srcOffsets[0] = {command.sourceRect.x, command.sourceRect.y, 0};
        blit.srcOffsets[1] = {command.sourceRect.x + command.sourceRect.width,
                              command.sourceRect.y + command.sourceRect.height, 1};
        blit.dstOffsets[0] = {command.destinationRect.x, command.destinationRect.y, 0};
        blit.dstOffsets[1] = {command.destinationRect.x + command.destinationRect.width,
                              command.destinationRect.y + command.destinationRect.height, 1};
        command.blit(record.commandBuffer, source.image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, info.image,
                     VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &blit, VK_FILTER_NEAREST);
        VkImageMemoryBarrier outgoing = incoming;
        outgoing.oldLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
        outgoing.newLayout = info.outgoingLayout;
        const bool release = info.outgoingQueueFamily != VK_QUEUE_FAMILY_IGNORED && info.outgoingQueueFamily != family;
        outgoing.srcQueueFamilyIndex = release ? family : VK_QUEUE_FAMILY_IGNORED;
        outgoing.dstQueueFamilyIndex = release ? info.outgoingQueueFamily : VK_QUEUE_FAMILY_IGNORED;
        outgoing.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
        outgoing.dstAccessMask = release ? 0 : info.outgoingAccess;
        if (!output.texture)
            source.context.CmdPipelineBarrier(record.commandBuffer, VK_PIPELINE_STAGE_TRANSFER_BIT,
                                              release ? VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT : info.outgoingStage, 0, 0,
                                              nullptr, 0, nullptr, 1, &outgoing);
    }
    static void CommitPresent(CelesteGraphicsPacket& packet, const void* data) noexcept
    {
        packet.Resource<VulkanOutputState>(static_cast<const PresentCommand*>(data)->output).submitted = true;
    }
    static void PresentImage(CelesteGraphicsPacket* packet, std::shared_ptr<TextureImage> source,
                             CelesteGraphicsOutput* output, const CelesteGraphicsRect* sourceRect,
                             const CelesteGraphicsRect* destinationRect)
    {
        if (!packet || !source || !output || !output->state || output->state->device != &packet->Owner())
            throw std::invalid_argument("Presentation requires source and output from the same device");
        packet->RequireOpen();
        const auto& info = output->state->info;
        if (source->image == info.image || output->state->submitted ||
            (!info.incomingStage && info.incomingLayout != VK_IMAGE_LAYOUT_UNDEFINED) || !info.outgoingStage ||
            info.outgoingLayout == VK_IMAGE_LAYOUT_UNDEFINED || info.outgoingLayout == VK_IMAGE_LAYOUT_PREINITIALIZED)
            throw std::invalid_argument(
                "Presentation requires valid distinct image layouts/stages and an unused output");
        if (std::find(packet->storage->outputs.begin(), packet->storage->outputs.end(), output->state.get()) !=
            packet->storage->outputs.end())
            throw std::logic_error("An output loan is used once per presentation");
        const auto from = Rect(sourceRect, source->extent), to = Rect(destinationRect, info.extent);
        PresentCommand command{packet->Retain(source), packet->Retain(output->state), from, to, nullptr};
        packet->RegisterImage(*source);
        if (output->state->texture)
            packet->RegisterImage(*output->state->texture);
        packet->storage->outputs.push_back(output->state.get());
        if (info.readySemaphore)
        {
            auto& waits = packet->storage->waitSemaphores;
            if (std::find(waits.begin(), waits.end(), info.readySemaphore) == waits.end())
            {
                waits.reserve(waits.size() + 1);
                packet->storage->waitStages.reserve(packet->storage->waitStages.size() + 1);
                waits.push_back(info.readySemaphore);
                packet->storage->waitStages.push_back(VK_PIPELINE_STAGE_TRANSFER_BIT);
            }
        }
        if (info.completeSemaphore)
        {
            auto& signals = packet->storage->signalSemaphores;
            if (std::find(signals.begin(), signals.end(), info.completeSemaphore) == signals.end())
                signals.push_back(info.completeSemaphore);
        }
        packet->AddCommand(command, PreparePresent, RecordPresent, CommitPresent);
    }
    void Present(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source, CelesteGraphicsOutput* output,
                 const CelesteGraphicsRect* from, const CelesteGraphicsRect* to)
    {
        if (!packet || !source || source->device != &packet->Owner())
            throw std::invalid_argument("Presentation source belongs to another device");
        PresentImage(packet, source->image, output, from, to);
    }
    void PresentBackbuffer(CelesteGraphicsPacket* packet, CelesteGraphicsOutput* output,
                           const CelesteGraphicsRect* from, const CelesteGraphicsRect* to)
    {
        if (!packet)
            throw std::invalid_argument("Presentation packet is null");
        ResolveBackbuffer(packet);
        PresentImage(packet, packet->Owner().Draws().backbuffer, output, from, to);
    }
    void GetCapabilities(CelesteGraphicsDevice* device, CelesteGraphicsCapabilities* capabilities)
    {
        if (!device || !capabilities)
            throw std::invalid_argument("Capabilities require device and output");
        *capabilities = {};
        capabilities->noOverwrite = 1;
        const auto supports = [&](VkFormat format, VkFormatFeatureFlags required) {
            return (device->Packets().Format(*device, format).optimalTilingFeatures & required) == required;
        };
        capabilities->srgbRenderTargets = supports(VK_FORMAT_R8G8B8A8_SRGB, VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT |
                                                                                VK_FORMAT_FEATURE_COLOR_ATTACHMENT_BIT);
        if (device->native.enabledFeatures.textureCompressionBC)
        {
            capabilities->dxt1 = supports(VK_FORMAT_BC1_RGBA_UNORM_BLOCK, VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT);
            capabilities->s3tc = capabilities->dxt1 &&
                                 supports(VK_FORMAT_BC2_UNORM_BLOCK, VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT) &&
                                 supports(VK_FORMAT_BC3_UNORM_BLOCK, VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT);
        }
        capabilities->fragmentTextureSlots = 16;
        capabilities->vertexTextureSlots = 4;
    }

}

namespace Celeste::Graphics::Vulkan
{
    void ReadBackbuffer(CelesteGraphicsPacket* packet, const CelesteGraphicsRect* requested,
                        CelesteGraphicsReadback** result)
    {
        if (result)
            *result = nullptr;
        if (!packet)
            throw std::invalid_argument("Backbuffer readback requires a packet");
        packet->RequireOpen();
        ResolveBackbuffer(packet);
        const auto image = packet->Owner().Draws().backbuffer;
        if (!image)
            throw std::logic_error("Backbuffer is not configured");
        const auto rect = Rect(requested, image->extent);
        const CelesteGraphicsTextureRegion region{0,
                                                  0,
                                                  static_cast<uint32_t>(rect.x),
                                                  static_cast<uint32_t>(rect.y),
                                                  0,
                                                  static_cast<uint32_t>(rect.width),
                                                  static_cast<uint32_t>(rect.height),
                                                  1};
        CelesteGraphicsTexture texture{&packet->Owner(), image, image->info, {}};
        ReadTexture(packet, &texture, &region, result);
    }
}
