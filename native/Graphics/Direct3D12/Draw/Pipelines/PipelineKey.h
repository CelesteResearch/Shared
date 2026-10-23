#pragma once
#include "SourcePipelineState.h"
#include "PipelineTargets.h"
#include <string>
#include <vector>
namespace Celeste::Graphics::Direct3D12
{
    struct PipelineKey
    {
        uint64_t shaderIdentity = 0;
        bool usesShaderIdentity = false;
        std::string shader;
        std::vector<uint32_t> fields;
        bool operator==(const PipelineKey& other) const noexcept
        {
            return usesShaderIdentity == other.usesShaderIdentity && shaderIdentity == other.shaderIdentity &&
                   shader == other.shader && fields == other.fields;
        }
    };

    PipelineKey MakePipelineKey(const std::string& shaderKey, const PipelineState&, const InputLayout&,
                                const PipelineTargets&, SourcePrimitiveType);
    // Identity must be stable and never reused for another program throughout the cache lifetime.
    PipelineKey MakePipelineKey(uint64_t shaderIdentity, const PipelineState&, const InputLayout&,
                                const PipelineTargets&, SourcePrimitiveType);
    void FillPipelineKey(uint64_t shaderIdentity, const PipelineState&, const InputLayout&, const PipelineTargets&,
                         SourcePrimitiveType, PipelineKey& destination);
    void FillPipelineKey(const std::string& shaderKey, const PipelineState&, const InputLayout&, const PipelineTargets&,
                         SourcePrimitiveType, PipelineKey& destination);
} // namespace Celeste::Graphics::Direct3D12
