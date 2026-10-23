#include "CelesteGraphicsOutput.h"
#include "CelesteGraphicsTexture.h"
#include "VulkanApiErrors.h"
#include <stdexcept>
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanAcquireOutput(CelesteGraphicsDevice* device,
                                                                    const CelesteVulkanOutputInfo* info,
                                                                    CelesteGraphicsOutput** output)
{
    if (output)
        *output = nullptr;
    return VulkanInvoke([&] {
        if (!device || !info || !output || !info->image || !info->extent.width || !info->extent.height)
            throw std::invalid_argument("Output acquisition requires device, image, extent and output");
        auto value = std::make_unique<CelesteGraphicsOutput>();
        value->state = std::make_shared<VulkanOutputState>();
        value->state->device = device;
        value->state->info = *info;
        *output = value.release();
    });
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanAcquireTextureOutput(CelesteGraphicsDevice* device,
                                                                           CelesteGraphicsTexture* texture,
                                                                           CelesteGraphicsOutput** output)
{
    if (output)
        *output = nullptr;
    return VulkanInvoke([&] {
        if (!device || !texture || !output || texture->device != device ||
            texture->info.dimension != CelesteGraphicsTexture2D || texture->image->samples != VK_SAMPLE_COUNT_1_BIT ||
            !texture->info.renderTarget)
            throw std::invalid_argument("Offscreen output requires a same-device resolved 2D render texture");
        auto value = std::make_unique<CelesteGraphicsOutput>();
        value->state = std::make_shared<VulkanOutputState>();
        value->state->device = device;
        value->state->texture = texture->image;
        auto& info = value->state->info;
        info.image = texture->image->image;
        info.extent = texture->image->extent;
        info.format = texture->image->format.native;
        info.incomingLayout = info.outgoingLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
        info.incomingStage = info.outgoingStage = VK_PIPELINE_STAGE_TRANSFER_BIT;
        info.incomingAccess = info.outgoingAccess = VK_ACCESS_TRANSFER_WRITE_BIT;
        info.incomingQueueFamily = info.outgoingQueueFamily = VK_QUEUE_FAMILY_IGNORED;
        *output = value.release();
    });
}
