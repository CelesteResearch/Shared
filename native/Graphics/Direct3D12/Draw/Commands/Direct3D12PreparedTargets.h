#pragma once
#include "Direct3D12DrawState.h"
#include "Binding/BindingBatch.h"
#include "PipelineTargets.h"
struct CelesteGraphicsPacket;
struct Direct3D12PacketRecordContext;
struct Direct3D12PreparedTargets
{
    std::array<Direct3D12TargetBinding, 4> colors;
    std::array<uint32_t, 4> subresources{};
    uint32_t count = 0;
    std::shared_ptr<Celeste::Graphics::Direct3D12::DepthResource> depth;
    std::shared_ptr<Celeste::Graphics::Direct3D12::BindingBatch> batch;
    Celeste::Graphics::Direct3D12::DescriptorRange renderViews;
    D3D12_CPU_DESCRIPTOR_HANDLE depthView{};
    Celeste::Graphics::Direct3D12::PipelineTargets formats;
    uint32_t width = 0, height = 0;
};
void PrepareTargets(CelesteGraphicsPacket& packet, const Direct3D12DrawState& state,
                    std::shared_ptr<Celeste::Graphics::Direct3D12::BindingBatch> batch,
                    Direct3D12PreparedTargets& result);
void BindTargets(const Direct3D12PreparedTargets& targets, Direct3D12PacketRecordContext& context) noexcept;
