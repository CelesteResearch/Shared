#pragma once
#include "Direct3D12EffectCache.h"
struct CelesteGraphicsPacket;
namespace Celeste::Graphics::Direct3D12
{
    void ApplyEffect(CelesteGraphicsPacket*, void* effect, uint32_t pass, void* changes);
    std::shared_ptr<const Direct3D12EffectProgram> PrepareShadersForLayout(const Direct3D12EffectSnapshot&,
                                                                           const D3D12_INPUT_ELEMENT_DESC*,
                                                                           size_t count);
}
