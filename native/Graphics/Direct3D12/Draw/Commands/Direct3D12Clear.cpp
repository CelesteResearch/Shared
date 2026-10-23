#include "Direct3D12Clear.h"
#include "Direct3D12DrawArena.h"
#include "Direct3D12PreparedTargets.h"
#include "Direct3D12DrawContext.h"
#include "CelesteGraphicsPacket.h"
#include <algorithm>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    namespace
    {
        struct ClearPayload
        {
            uint32_t stateIndex, preparedIndex;
            SourceClearOptions options;
            float color[4];
            float depth;
            uint8_t stencil;
        };
        void PrepareClear(CelesteGraphicsPacket& packet, void* data)
        {
            auto& payload = *static_cast<ClearPayload*>(data);
            BindingRequirements needed;
            needed.rtvCount = 4;
            needed.dsvCount = 1;
            auto& arena = GetDrawArena(packet);
            payload.preparedIndex = arena.AddClear();
            PrepareTargets(packet, packet.Resource<Direct3D12DrawState>(payload.stateIndex),
                           GetBindingBatch(packet, needed), arena.clears[payload.preparedIndex]);
        }
        void RecordClear(CelesteGraphicsPacket& packet, const void* data,
                         Direct3D12PacketRecordContext& context) noexcept
        {
            const auto& payload = *static_cast<const ClearPayload*>(data);
            const auto& targets = packet.drawArena->clears[payload.preparedIndex];
            BindTargets(targets, context);
            auto* list = context.lease.List();
            if (payload.options & SourceClearOptions_Target)
            {
                for (uint32_t i = 0; i < targets.count; ++i)
                {
                    auto handle = targets.renderViews.cpu;
                    handle.ptr += static_cast<SIZE_T>(i) * targets.renderViews.increment;
                    list->ClearRenderTargetView(handle, payload.color, 0, nullptr);
                }
            }
            if (!targets.depth)
                return;
            UINT flags = 0;
            if (payload.options & SourceClearOptions_DepthBuffer)
                flags |= D3D12_CLEAR_FLAG_DEPTH;
            if ((payload.options & SourceClearOptions_Stencil) &&
                (targets.formats.depth == DXGI_FORMAT_D24_UNORM_S8_UINT ||
                 targets.formats.depth == DXGI_FORMAT_D32_FLOAT_S8X24_UINT))
                flags |= D3D12_CLEAR_FLAG_STENCIL;
            if (flags)
                list->ClearDepthStencilView(targets.depthView, static_cast<D3D12_CLEAR_FLAGS>(flags), payload.depth,
                                            payload.stencil, 0, nullptr);
        }
    } // namespace
    void Clear(CelesteGraphicsPacket* packet, SourceClearOptions options, const float* rgba, float depth,
               int32_t stencil)
    {
        if (!packet)
            throw std::invalid_argument("Clear packet is null");
        packet->RequireOpen();
        if ((options & SourceClearOptions_Target) && !rgba)
            throw std::invalid_argument("Clear color is null");
        ClearPayload payload{};
        payload.options = options;
        payload.depth = std::clamp(depth, 0.0f, 1.0f);
        payload.stencil = static_cast<uint8_t>(stencil);
        if (rgba)
            std::copy_n(rgba, 4, payload.color);
        const auto& state = GetDrawState(*packet);
        auto snapshot = std::make_shared<Direct3D12DrawState>();
        snapshot->usesBackbuffer = state.usesBackbuffer;
        snapshot->backbuffer = state.backbuffer;
        snapshot->backbufferMsaa = state.backbufferMsaa;
        snapshot->backbufferDepth = state.backbufferDepth;
        snapshot->targets = state.targets;
        snapshot->depth = state.depth;
        payload.stateIndex = packet->Retain(std::move(snapshot));
        packet->AddCommand(payload, PrepareClear, RecordClear);
    }
} // namespace Celeste::Graphics::Direct3D12
