#include "VulkanColorRenderbufferApi.h"
#include "ResolveTargetCommand.h"
#include "CelesteGraphicsRenderbuffer.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsPacket.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    void GetMaxMultiSampleCount(CelesteGraphicsDevice* device, SourceSurfaceFormat source, int32_t preferred,
                                int32_t* count)
    {
        if (!device || !count || preferred < 0)
            throw std::invalid_argument("Invalid multisample capability query");
        *count = 0;
        const auto format = TextureFormat::FromSource(source);
        if (!preferred || format.Compressed())
            return;
        const auto& native = device->Resources()->native;
        auto query = reinterpret_cast<PFN_vkGetPhysicalDeviceImageFormatProperties>(
            native.getInstanceProcAddr(native.instance, "vkGetPhysicalDeviceImageFormatProperties"));
        VkImageFormatProperties properties{};
        const auto result = query(native.physicalDevice, format.native, VK_IMAGE_TYPE_2D, VK_IMAGE_TILING_OPTIMAL,
                                  VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT | VK_IMAGE_USAGE_TRANSFER_SRC_BIT |
                                      VK_IMAGE_USAGE_TRANSFER_DST_BIT,
                                  0, &properties);
        if (result == VK_ERROR_FORMAT_NOT_SUPPORTED)
            return;
        if (result != VK_SUCCESS)
            throw std::runtime_error("Multisample image format query failed");
        for (int32_t candidate = preferred; candidate > 0; candidate >>= 1)
            if (candidate <= 64 && !(candidate & (candidate - 1)) && (properties.sampleCounts & candidate))
            {
                *count = candidate;
                return;
            }
    }
    void CreateColorRenderbuffer(CelesteGraphicsDevice* device, int32_t width, int32_t height,
                                 SourceSurfaceFormat format, int32_t samples, CelesteGraphicsTexture* texture,
                                 CelesteGraphicsRenderbuffer** output)
    {
        if (output)
            *output = nullptr;
        if (!device || !output || width <= 0 || height <= 0 || samples < 0)
            throw std::invalid_argument("Invalid color renderbuffer parameters");
        const int32_t actualSamples = samples ? samples : 1;
        int32_t supported = 0;
        GetMaxMultiSampleCount(device, format, actualSamples, &supported);
        if (supported != actualSamples)
            throw std::invalid_argument("Requested color renderbuffer sample count unsupported");
        if (texture && (texture->device != device || texture->info.width != uint32_t(width) ||
                        texture->info.height != uint32_t(height) || texture->info.sourceFormat != format ||
                        !texture->info.renderTarget || texture->info.dimension == 1))
            throw std::invalid_argument("Color renderbuffer texture mismatch");
        auto result = std::make_unique<CelesteGraphicsRenderbuffer>();
        result->device = device;
        if (actualSamples == 1 && texture)
            result->color = texture->image;
        else
        {
            CelesteGraphicsTextureInfo info{};
            info.width = width;
            info.height = height;
            info.depth = 1;
            info.levels = 1;
            info.sourceFormat = format;
            info.renderTarget = 1;
            result->color = std::make_shared<TextureImage>(device->Resources(), info,
                                                           static_cast<VkSampleCountFlagBits>(actualSamples));
        }
        *output = result.release();
    }
    static void RecordResolve(CelesteGraphicsPacket& packet, const void* bytes,
                              VulkanPacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const ResolveTargetCommand*>(bytes);
        auto& destination = packet.Resource<TextureImage>(command.destination);
        if (command.resolve)
            recording.images.Resolve(packet.Resource<TextureImage>(command.source), destination, 0, command.layer);
        if (command.mipmaps)
            recording.images.GenerateMipmaps(destination);
    }
    void ResolveTarget(CelesteGraphicsPacket* packet, const SourceNativeRenderTargetBinding* binding)
    {
        if (!packet || !binding)
            throw std::invalid_argument("Missing resolve packet or binding");
        packet->RequireOpen();
        if (binding->multiSampleCount <= 0 && binding->levelCount <= 1)
            return;
        auto* texture = static_cast<CelesteGraphicsTexture*>(binding->texture);
        if (!texture || texture->device != &packet->Owner())
            throw std::invalid_argument("Resolve texture device mismatch");
        auto& destination = *texture->image;
        const uint32_t layer = binding->type == 1 ? uint32_t(binding->data2) : 0;
        destination.StateIndex(0, layer);
        const bool mipmaps = binding->levelCount > 1;
        const VkFormatFeatureFlags mipFeatures = VK_FORMAT_FEATURE_BLIT_SRC_BIT | VK_FORMAT_FEATURE_BLIT_DST_BIT |
                                                 VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_LINEAR_BIT;
        if (mipmaps && (destination.formatFeatures & mipFeatures) != mipFeatures)
            throw std::invalid_argument("Resolve target does not support linear mipmap generation");
        auto* buffer = static_cast<CelesteGraphicsRenderbuffer*>(binding->colorBuffer);
        std::shared_ptr<TextureImage> source;
        if (binding->multiSampleCount > 0 && buffer)
        {
            if (buffer->device != &packet->Owner() || !buffer->color)
                throw std::invalid_argument("Resolve color buffer mismatch");
            source = buffer->color;
            if (source->image != destination.image &&
                (source->format.native != destination.format.native ||
                 source->extent.width != destination.extent.width ||
                 source->extent.height != destination.extent.height || destination.samples != VK_SAMPLE_COUNT_1_BIT))
                throw std::invalid_argument("Resolve image format or extent mismatch");
        }
        const bool resolve = source && source->image != destination.image;
        if (!resolve && !mipmaps)
            return;
        ResolveTargetCommand command{resolve ? packet->Retain(source) : 0, packet->Retain(texture->image), layer,
                                     resolve, mipmaps};
        if (resolve)
            packet->RegisterImage(*source);
        packet->RegisterImage(destination);
        packet->AddCommand(command, nullptr, RecordResolve);
    }
}
