#pragma once
#include "CelesteGraphicsDirect3D12.h"
#include "DeviceContext.h"
#include "SubmissionQueue.h"
#include "TransferBufferPool.h"
#include <memory>
namespace Celeste::Graphics::Direct3D12
{
    class PresentationContext;
}
struct Direct3D12DrawContext;
struct Direct3D12DrawArenaPool;
struct CelesteGraphicsDevice
{
    std::shared_ptr<Direct3D12DrawArenaPool> drawArenas;
    std::shared_ptr<Direct3D12DrawContext> drawContext;
    std::shared_ptr<Celeste::Graphics::Direct3D12::PresentationContext> presentation;
    std::shared_ptr<Celeste::Graphics::Direct3D12::DeviceContext> context;
    std::shared_ptr<Celeste::Graphics::Direct3D12::TransferBufferPool> transfers;
    Celeste::Graphics::Direct3D12::SubmissionQueue* submissions = nullptr;
    bool host = false;
    auto Resources() const
    {
        return context;
    }
    auto TransferBuffers()
    {
        if (!transfers)
            transfers = std::make_shared<Celeste::Graphics::Direct3D12::TransferBufferPool>(context);
        return transfers;
    }
};
