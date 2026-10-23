#pragma once
#include "PipelineKeyHash.h"
#include "PipelineObjects.h"
#include "CompiledShaders.h"
#include <unordered_map>
namespace Celeste::Graphics::Direct3D12
{
    class PipelineCache
    {
        std::shared_ptr<DeviceContext> context;
        Microsoft::WRL::ComPtr<ID3D12RootSignature> root;
        std::unordered_map<PipelineKey, std::shared_ptr<PipelineObjects>, PipelineKeyHash> entries;

        PipelineKey scratch;
        std::shared_ptr<PipelineObjects> AcquireKey(const PipelineKey& key, const CompiledShaders&,
                                                    const PipelineState&, const InputLayout&, const PipelineTargets&,
                                                    SourcePrimitiveType);

      public:
        explicit PipelineCache(std::shared_ptr<DeviceContext>);
        // Owner-thread preparation only. Retain returned objects in CommandLease until completion.
        std::shared_ptr<PipelineObjects> Acquire(const std::string& shaderKey, const CompiledShaders&,
                                                 const PipelineState&, const InputLayout&, const PipelineTargets&,
                                                 SourcePrimitiveType);
        // Program identity remains owned and unique for this device cache lifetime.
        std::shared_ptr<PipelineObjects> Acquire(uint64_t shaderIdentity, const CompiledShaders&, const PipelineState&,
                                                 const InputLayout&, const PipelineTargets&, SourcePrimitiveType);
    };
} // namespace Celeste::Graphics::Direct3D12
