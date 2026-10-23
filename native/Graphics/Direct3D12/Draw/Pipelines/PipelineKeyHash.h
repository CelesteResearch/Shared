#pragma once
#include "PipelineKey.h"
namespace Celeste::Graphics::Direct3D12
{
    struct PipelineKeyHash
    {
        size_t operator()(const PipelineKey&) const noexcept;
    };
} // namespace Celeste::Graphics::Direct3D12
