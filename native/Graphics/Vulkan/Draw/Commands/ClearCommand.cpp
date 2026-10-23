#include "ClearCommand.h"
namespace Celeste::Graphics::Vulkan
{
    void ClearCommand::Record(CelesteGraphicsPacket& packet, const void* data,
                              VulkanPacketRecordContext& context) noexcept
    {
        const auto& command = *static_cast<const ClearCommand*>(data);
        if (command.image != UINT32_MAX)
            context.images.Clear(packet.Resource<TextureImage>(command.image), command.value, command.level,
                                 command.layer);
        if (command.depth != UINT32_MAX)
            context.depth.Clear(packet.Resource<DepthStencilAttachment>(command.depth), command.depthValue,
                                command.stencilValue, command.depthAspects);
    }
}
