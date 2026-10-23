#include "InitializeNullTextureCommand.h"
#include "TextureImage.h"
#include "VulkanPacketRecordContext.h"
namespace Celeste::Graphics::Vulkan
{
    void InitializeNullTextureCommand::Record(CelesteGraphicsPacket& packet, const void* bytes,
                                              VulkanPacketRecordContext& context) noexcept
    {
        const auto& command = *static_cast<const InitializeNullTextureCommand*>(bytes);
        auto& image = packet.Resource<TextureImage>(command.image);
        VkClearColorValue zero{};
        for (uint32_t layer = 0; layer < image.layers; ++layer)
            context.images.Clear(image, zero, 0, layer);
    }
}
