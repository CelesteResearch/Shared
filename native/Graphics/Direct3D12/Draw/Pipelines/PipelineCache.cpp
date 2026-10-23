#include "PipelineCache.h"
#include "SourceRootSignature.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    PipelineCache::PipelineCache(std::shared_ptr<DeviceContext> owner) : context(std::move(owner))
    {
        if (!context || !context->device)
            throw std::invalid_argument("Pipeline cache requires a D3D12 device context");
        root = SourceRootSignature{}.Create(context->device.Get());
    }
    std::shared_ptr<PipelineObjects> PipelineCache::Acquire(const std::string& shaderKey,
                                                            const CompiledShaders& shaders, const PipelineState& state,
                                                            const InputLayout& input, const PipelineTargets& targets,
                                                            SourcePrimitiveType primitive)
    {
        FillPipelineKey(shaderKey, state, input, targets, primitive, scratch);
        return AcquireKey(scratch, shaders, state, input, targets, primitive);
    }
    std::shared_ptr<PipelineObjects> PipelineCache::Acquire(uint64_t shaderIdentity, const CompiledShaders& shaders,
                                                            const PipelineState& state, const InputLayout& input,
                                                            const PipelineTargets& targets,
                                                            SourcePrimitiveType primitive)
    {
        FillPipelineKey(shaderIdentity, state, input, targets, primitive, scratch);
        return AcquireKey(scratch, shaders, state, input, targets, primitive);
    }
    std::shared_ptr<PipelineObjects> PipelineCache::AcquireKey(const PipelineKey& key, const CompiledShaders& shaders,
                                                               const PipelineState& state, const InputLayout& input,
                                                               const PipelineTargets& targets,
                                                               SourcePrimitiveType primitive)
    {
        if (const auto found = entries.find(key); found != entries.end())
            return found->second;
        if (!shaders.vertex || !shaders.pixel)
            throw std::invalid_argument("Pipeline requires compiled vertex and pixel shaders");
        D3D12_GRAPHICS_PIPELINE_STATE_DESC description{};
        description.pRootSignature = root.Get();
        description.VS = {shaders.vertex->GetBufferPointer(), shaders.vertex->GetBufferSize()};
        description.PS = {shaders.pixel->GetBufferPointer(), shaders.pixel->GetBufferSize()};
        description.BlendState = state.blend;
        description.DepthStencilState = state.depth;
        description.RasterizerState = state.rasterizer;
        description.SampleMask = state.sampleMask;
        description.SampleDesc = targets.samples;
        description.PrimitiveTopologyType = ConvertTopologyType(primitive);
        description.InputLayout = {input.elements.data(), static_cast<UINT>(input.elements.size())};
        description.NumRenderTargets = targets.colorCount;
        description.DSVFormat = targets.depth;
        // With no depth attachment the source depth/stencil tests have no observable effect.
        if (targets.depth == DXGI_FORMAT_UNKNOWN)
        {
            description.DepthStencilState.DepthEnable = FALSE;
            description.DepthStencilState.DepthWriteMask = D3D12_DEPTH_WRITE_MASK_ZERO;
            description.DepthStencilState.StencilEnable = FALSE;
        }
        else if (targets.depth == DXGI_FORMAT_D16_UNORM || targets.depth == DXGI_FORMAT_D32_FLOAT)
            description.DepthStencilState.StencilEnable = FALSE;
        for (UINT i = 0; i < targets.colorCount; ++i)
            description.RTVFormats[i] = targets.colors[i];
        // Source strips do not use restart indices; retain the default disabled strip-cut value.
        auto result = std::make_shared<PipelineObjects>();
        result->context = context;
        result->root = root;
        result->topology = ConvertTopology(primitive);
        CheckResult(context->device->CreateGraphicsPipelineState(&description, IID_PPV_ARGS(&result->pipeline)),
                    "CreateGraphicsPipelineState");
        entries.emplace(key, result);
        return result;
    }
} // namespace Celeste::Graphics::Direct3D12
