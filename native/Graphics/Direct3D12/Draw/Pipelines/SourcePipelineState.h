#pragma once
#include "CelesteGraphicsSourceTypes.h"
#include <d3d12.h>
#include "PipelineState.h"
#include "DynamicState.h"
#include "InputLayout.h"
#include <vector>

namespace Celeste::Graphics::Direct3D12
{
    PipelineState ConvertPipelineState(const SourceNativeBlendState&, const SourceNativeDepthStencilState&,
                                       const SourceNativeRasterizerState&, SourceDepthFormat actualDepthFormat);
    DynamicState ConvertDynamicState(const SourceNativeBlendState&, const SourceNativeDepthStencilState&,
                                     const SourceNativeRasterizerState&);
    InputLayout ConvertInputLayout(const SourceNativeVertexBufferBinding*, int32_t count);
    DXGI_FORMAT ConvertVertexFormat(SourceVertexElementFormat);
    D3D12_PRIMITIVE_TOPOLOGY ConvertTopology(SourcePrimitiveType);
    D3D12_PRIMITIVE_TOPOLOGY_TYPE ConvertTopologyType(SourcePrimitiveType);
    D3D12_RECT ResolveScissor(const DynamicState&, D3D12_RECT requested, int32_t targetWidth, int32_t targetHeight);
} // namespace Celeste::Graphics::Direct3D12
