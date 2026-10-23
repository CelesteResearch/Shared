#pragma once
#include "PipelineCache.h"
#include "BindingPool.h"
#include "Direct3D12DrawState.h"
struct Direct3D12PacketCompletion;
struct Direct3D12EffectCache;
struct CelesteGraphicsPacket;
struct CelesteGraphicsDevice;
struct Direct3D12DrawContext
{
    std::shared_ptr<Direct3D12EffectCache> effects;
    std::weak_ptr<Direct3D12DrawState> readView;
    std::weak_ptr<Direct3D12PacketCompletion> readCompletion;
    Celeste::Graphics::Direct3D12::PipelineCache pipelines;
    Celeste::Graphics::Direct3D12::BindingPool bindings;
    std::shared_ptr<Direct3D12DrawState> committed = std::make_shared<Direct3D12DrawState>();
    explicit Direct3D12DrawContext(std::shared_ptr<Celeste::Graphics::Direct3D12::DeviceContext> context)
        : pipelines(context), bindings(std::move(context))
    {
    }
};
Direct3D12DrawContext& GetDrawContext(CelesteGraphicsDevice&);
Direct3D12DrawState& GetDrawState(CelesteGraphicsPacket&);

std::shared_ptr<Celeste::Graphics::Direct3D12::BindingBatch> GetBindingBatch(
    CelesteGraphicsPacket&, const Celeste::Graphics::Direct3D12::BindingRequirements&);

std::shared_ptr<Direct3D12DrawState> GetReadableDrawState(CelesteGraphicsDevice&);

std::shared_ptr<Direct3D12DrawState> GetDrawSnapshot(CelesteGraphicsPacket&);
