#pragma once
#include <d3d12.h>
#include "EffectFrontendAbi.h"
#include "PreparedShaders.h"
#include "CompiledShaders.h"
namespace Celeste::Graphics::Direct3D12
{
    // Supply only semantics consumed by the vertex shader. Full declaration slot,
    // offset, classification and stride remain part of the caller's PSO key.
    PreparedShaders PrepareShaders(const CelesteEffectShaderDescription& vertex,
                                   const CelesteEffectShaderDescription& pixel,
                                   const D3D12_INPUT_ELEMENT_DESC* elements, size_t count);
    CompiledShaders CompileShaders(const PreparedShaders& shaders);
}
