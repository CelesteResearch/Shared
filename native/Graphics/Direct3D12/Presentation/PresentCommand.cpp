#include "PresentCommand.h"
#include "PresentationContext.h"
#include "PresentationOutput.h"
namespace Celeste::Graphics::Direct3D12
{
    void PresentCommand::Prepare(CelesteGraphicsPacket& packet, void* data)
    {
        auto& command = *static_cast<PresentCommand*>(data);
        if (command.copy)
            return;
        auto& device = packet.Owner();
        if (!device.presentation)
            device.presentation = std::make_shared<PresentationContext>(device.context);
        const auto& output = packet.Resource<PresentationOutput>(command.output);
        const auto source = std::static_pointer_cast<TextureResource>(packet.storage->resources[command.source]);
        command.prepared = packet.Retain(device.presentation->Prepare(source, output.info, command.from, command.to));
    }
    void PresentCommand::Record(CelesteGraphicsPacket& packet, const void* data,
                                Direct3D12PacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const PresentCommand*>(data);
        if (command.copy)
        {
            auto& source = packet.Resource<TextureResource>(command.source);
            const auto& output = packet.Resource<PresentationOutput>(command.output);
            auto* list = recording.lease.List();
            recording.states.Transition(source, 0, D3D12_RESOURCE_STATE_COPY_SOURCE);
            D3D12_RESOURCE_BARRIER barrier{};
            barrier.Type = D3D12_RESOURCE_BARRIER_TYPE_TRANSITION;
            barrier.Transition = {output.resource.Get(), D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES,
                                  output.info.incomingState, D3D12_RESOURCE_STATE_COPY_DEST};
            if (output.texture)
                recording.states.Transition(*output.texture, 0, D3D12_RESOURCE_STATE_COPY_DEST);
            else if (output.info.incomingState != D3D12_RESOURCE_STATE_COPY_DEST)
                list->ResourceBarrier(1, &barrier);
            D3D12_TEXTURE_COPY_LOCATION from{};
            from.pResource = source.resource.Get();
            from.Type = D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX;
            D3D12_TEXTURE_COPY_LOCATION to{};
            to.pResource = output.resource.Get();
            to.Type = D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX;
            to.SubresourceIndex = output.info.subresource;
            list->CopyTextureRegion(&to, 0, 0, 0, &from, nullptr);
            barrier.Transition.StateBefore = D3D12_RESOURCE_STATE_COPY_DEST;
            barrier.Transition.StateAfter = output.info.outgoingState;
            if (!output.texture && output.info.outgoingState != D3D12_RESOURCE_STATE_COPY_DEST)
                list->ResourceBarrier(1, &barrier);
            return;
        }
        const auto& binding = packet.Resource<PresentationBinding>(command.prepared);
        recording.states.Transition(*binding.source, 0, D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE);
        const auto& output = packet.Resource<PresentationOutput>(command.output);
        if (output.texture)
        {
            recording.states.Transition(*output.texture, 0, D3D12_RESOURCE_STATE_RENDER_TARGET);
            const float black[4] = {0, 0, 0, 1};
            if (command.to.x != 0 || command.to.y != 0 || uint32_t(command.to.width) != output.info.width ||
                uint32_t(command.to.height) != output.info.height)
                recording.lease.List()->ClearRenderTargetView(
                    binding.descriptors->renderHeap->GetCPUDescriptorHandleForHeapStart(), black, 0, nullptr);
            binding.Draw(recording.lease.List());
        }
        else
            binding.Record(recording.lease.List());
    }
}
