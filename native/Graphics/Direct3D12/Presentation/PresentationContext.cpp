#include "PresentationContext.h"
#include "PresentationVertex.h"
#include "PresentationPixel.h"
#include "PresentationArrayPixel.h"
#include <algorithm>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    PresentationContext::PresentationContext(std::shared_ptr<DeviceContext> owner) : context(std::move(owner))
    {
        D3D12_DESCRIPTOR_RANGE range{D3D12_DESCRIPTOR_RANGE_TYPE_SRV, 1, 0, 0, 0};
        D3D12_ROOT_PARAMETER parameters[2]{};
        parameters[0].ParameterType = D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS;
        parameters[0].Constants = {0, 0, 4};
        parameters[0].ShaderVisibility = D3D12_SHADER_VISIBILITY_VERTEX;
        parameters[1].ParameterType = D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE;
        parameters[1].DescriptorTable = {1, &range};
        parameters[1].ShaderVisibility = D3D12_SHADER_VISIBILITY_PIXEL;
        D3D12_STATIC_SAMPLER_DESC sampler{};
        sampler.Filter = D3D12_FILTER_MIN_MAG_MIP_POINT;
        sampler.AddressU = sampler.AddressV = sampler.AddressW = D3D12_TEXTURE_ADDRESS_MODE_CLAMP;
        sampler.MaxAnisotropy = 1;
        sampler.ComparisonFunc = D3D12_COMPARISON_FUNC_ALWAYS;
        sampler.MaxLOD = D3D12_FLOAT32_MAX;
        sampler.ShaderVisibility = D3D12_SHADER_VISIBILITY_PIXEL;
        D3D12_ROOT_SIGNATURE_DESC description{};
        description.NumParameters = 2;
        description.pParameters = parameters;
        description.NumStaticSamplers = 1;
        description.pStaticSamplers = &sampler;
        Microsoft::WRL::ComPtr<ID3DBlob> blob, error;
        for (int filter = 0; filter < 2; ++filter)
        {
            sampler.Filter = filter ? D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT : D3D12_FILTER_MIN_MAG_MIP_POINT;
            blob.Reset();
            error.Reset();
            CheckResult(D3D12SerializeRootSignature(&description, D3D_ROOT_SIGNATURE_VERSION_1, &blob, &error),
                        "Serialize presentation root signature");
            CheckResult(context->device->CreateRootSignature(0, blob->GetBufferPointer(), blob->GetBufferSize(),
                                                             IID_PPV_ARGS(&roots[filter])),
                        "Create presentation root signature");
        }
    }
    std::shared_ptr<PresentationPipeline> PresentationContext::Pipeline(DXGI_FORMAT format, bool linear,
                                                                        bool arraySource)
    {
        const uint64_t key = (uint64_t(format) << 2) | (linear ? 2u : 0u) | (arraySource ? 1u : 0u);
        const auto found = pipelines.find(key);
        if (found != pipelines.end())
            return found->second;
        D3D12_GRAPHICS_PIPELINE_STATE_DESC description{};
        description.pRootSignature = roots[linear ? 1 : 0].Get();
        description.VS = {PresentationVertex, sizeof(PresentationVertex)};
        description.PS = arraySource ? D3D12_SHADER_BYTECODE{PresentationArrayPixel, sizeof(PresentationArrayPixel)}
                                     : D3D12_SHADER_BYTECODE{PresentationPixel, sizeof(PresentationPixel)};
        auto& blend = description.BlendState.RenderTarget[0];
        blend.SrcBlend = blend.SrcBlendAlpha = D3D12_BLEND_ONE;
        blend.DestBlend = blend.DestBlendAlpha = D3D12_BLEND_ZERO;
        blend.BlendOp = blend.BlendOpAlpha = D3D12_BLEND_OP_ADD;
        blend.LogicOp = D3D12_LOGIC_OP_NOOP;
        blend.RenderTargetWriteMask = D3D12_COLOR_WRITE_ENABLE_ALL;
        description.SampleMask = UINT_MAX;
        description.SampleDesc.Count = 1;
        description.RasterizerState.FillMode = D3D12_FILL_MODE_SOLID;
        description.RasterizerState.CullMode = D3D12_CULL_MODE_NONE;
        description.RasterizerState.DepthClipEnable = TRUE;
        description.DepthStencilState.DepthWriteMask = D3D12_DEPTH_WRITE_MASK_ZERO;
        description.DepthStencilState.DepthFunc = D3D12_COMPARISON_FUNC_ALWAYS;
        description.DepthStencilState.FrontFace = {D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP_KEEP,
                                                   D3D12_COMPARISON_FUNC_ALWAYS};
        description.DepthStencilState.BackFace = description.DepthStencilState.FrontFace;
        description.PrimitiveTopologyType = D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE;
        description.NumRenderTargets = 1;
        description.RTVFormats[0] = format;
        auto result = std::make_shared<PresentationPipeline>();
        result->root = roots[linear ? 1 : 0];
        CheckResult(context->device->CreateGraphicsPipelineState(&description, IID_PPV_ARGS(&result->pipeline)),
                    "Create presentation pipeline");
        pipelines.emplace(key, result);
        return result;
    }
    std::shared_ptr<PresentationBinding> PresentationContext::Binding(DXGI_FORMAT format, bool linear, bool arraySource)
    {
        auto pipeline = Pipeline(format, linear, arraySource);
        auto binding = std::make_shared<PresentationBinding>();
        for (const auto& cached : descriptors)
            if (cached.use_count() == 1)
            {
                binding->descriptors = cached;
                break;
            }
        if (!binding->descriptors)
        {
            binding->descriptors = std::make_shared<PresentationDescriptors>(*context);
            descriptors.push_back(binding->descriptors);
        }
        binding->pipeline = std::move(pipeline);
        return binding;
    }
    std::shared_ptr<PresentationBinding> PresentationContext::Prepare(std::shared_ptr<TextureResource> source,
                                                                      const CelesteDirect3D12OutputInfo& output,
                                                                      const CelesteGraphicsRect& from,
                                                                      const CelesteGraphicsRect& to)
    {
        auto binding = Binding(output.format, false, false);
        binding->source = std::move(source);
        binding->output = output.resource;
        binding->info = output;
        binding->viewport = {static_cast<float>(to.x),
                             static_cast<float>(to.y),
                             static_cast<float>(to.width),
                             static_cast<float>(to.height),
                             0,
                             1};
        binding->scissor = {to.x, to.y, to.x + to.width, to.y + to.height};
        binding->uv[0] = float(from.x) / binding->source->info.width;
        binding->uv[1] = float(from.y) / binding->source->info.height;
        binding->uv[2] = float(from.width) / binding->source->info.width;
        binding->uv[3] = float(from.height) / binding->source->info.height;
        binding->source->CreateShaderView(binding->descriptors->shaderHeap->GetCPUDescriptorHandleForHeapStart());
        const auto desc = output.resource->GetDesc();
        D3D12_RENDER_TARGET_VIEW_DESC view{};
        view.Format = output.format;
        if (desc.DepthOrArraySize > 1)
        {
            view.ViewDimension = D3D12_RTV_DIMENSION_TEXTURE2DARRAY;
            view.Texture2DArray = {output.subresource % desc.MipLevels, output.subresource / desc.MipLevels, 1, 0};
        }
        else
        {
            view.ViewDimension = D3D12_RTV_DIMENSION_TEXTURE2D;
            view.Texture2D.MipSlice = output.subresource;
        }
        context->device->CreateRenderTargetView(output.resource, &view,
                                                binding->descriptors->renderHeap->GetCPUDescriptorHandleForHeapStart());
        return binding;
    }
    std::shared_ptr<PresentationBinding> PresentationContext::PrepareSample(std::shared_ptr<TextureResource> source,
                                                                            uint32_t sourceMip, uint32_t sourceLayer,
                                                                            std::shared_ptr<TextureResource> target,
                                                                            uint32_t targetMip, uint32_t targetLayer,
                                                                            bool linear)
    {
        if (!source || !target || source->context != context || target->context != context)
            throw std::invalid_argument("Resample resources must belong to this device");
        if (source->info.dimension == CelesteGraphicsTexture3D || target->info.dimension == CelesteGraphicsTexture3D ||
            source->description.SampleDesc.Count != 1 || target->description.SampleDesc.Count != 1)
            throw std::invalid_argument("Resample requires resolved 2D or cube slices");
        const auto sourceSubresource = source->Subresource(sourceMip, sourceLayer),
                   targetSubresource = target->Subresource(targetMip, targetLayer);
        if (source == target && sourceSubresource == targetSubresource)
            throw std::invalid_argument("Resample source and target subresources overlap");
        if (!target->info.renderTarget)
            throw std::invalid_argument("Resample destination is not renderable");
        if (filterableFormats.find(source->format.native) == filterableFormats.end())
        {
            D3D12_FEATURE_DATA_FORMAT_SUPPORT support{source->format.native};
            CheckResult(context->device->CheckFeatureSupport(D3D12_FEATURE_FORMAT_SUPPORT, &support, sizeof(support)),
                        "Query resample format support");
            if (!(support.Support1 & D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE))
                throw std::invalid_argument("Resample source format does not support filtering");
            filterableFormats.insert(source->format.native);
        }
        auto binding = Binding(target->format.native, linear, true);
        binding->source = std::move(source);
        binding->output = target->resource;
        const auto width = std::max(1u, target->info.width >> targetMip),
                   height = std::max(1u, target->info.height >> targetMip);
        binding->viewport = {0, 0, static_cast<float>(width), static_cast<float>(height), 0, 1};
        binding->scissor = {0, 0, static_cast<LONG>(width), static_cast<LONG>(height)};
        binding->uv[0] = binding->uv[1] = 0;
        binding->uv[2] = binding->uv[3] = 1;
        D3D12_SHADER_RESOURCE_VIEW_DESC view{};
        view.Format = binding->source->format.native;
        view.Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING;
        view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURE2DARRAY;
        view.Texture2DArray = {sourceMip, 1, sourceLayer, 1, 0, 0};
        context->device->CreateShaderResourceView(
            binding->source->resource.Get(), &view,
            binding->descriptors->shaderHeap->GetCPUDescriptorHandleForHeapStart());
        target->CreateRenderView(binding->descriptors->renderHeap->GetCPUDescriptorHandleForHeapStart(), targetMip,
                                 targetLayer);
        return binding;
    }
}
