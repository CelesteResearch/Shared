#include "PipelineKeyHash.h"
#include <cstring>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    namespace
    {
        uint32_t FloatBits(float value)
        {
            uint32_t bits;
            std::memcpy(&bits, &value, sizeof(bits));
            return bits;
        }
        void Face(std::vector<uint32_t>& key, const D3D12_DEPTH_STENCILOP_DESC& face)
        {
            key.insert(key.end(),
                       {static_cast<uint32_t>(face.StencilFailOp), static_cast<uint32_t>(face.StencilDepthFailOp),
                        static_cast<uint32_t>(face.StencilPassOp), static_cast<uint32_t>(face.StencilFunc)});
        }
        void Text(std::vector<uint32_t>& key, const char* text)
        {
            if (!text)
                throw std::invalid_argument("Input semantic name is null");
            const auto length = std::strlen(text);
            key.push_back(static_cast<uint32_t>(length));
            for (size_t i = 0; i < length; ++i)
                key.push_back(static_cast<unsigned char>(text[i]));
        }
    } // namespace
    static void FillStateKey(const PipelineState& state, const InputLayout& input, const PipelineTargets& targets,
                             SourcePrimitiveType topology, PipelineKey& result)
    {
        if (targets.colorCount > targets.colors.size() || !targets.samples.Count)
            throw std::invalid_argument("Invalid pipeline targets");
        auto& key = result.fields;
        key.clear();
        key.reserve(180 + input.elements.size() * 20 + input.strides.size());
        key.push_back(state.blend.AlphaToCoverageEnable);
        key.push_back(state.blend.IndependentBlendEnable);
        for (const auto& target : state.blend.RenderTarget)
            key.insert(key.end(),
                       {static_cast<uint32_t>(target.BlendEnable), static_cast<uint32_t>(target.LogicOpEnable),
                        static_cast<uint32_t>(target.SrcBlend), static_cast<uint32_t>(target.DestBlend),
                        static_cast<uint32_t>(target.BlendOp), static_cast<uint32_t>(target.SrcBlendAlpha),
                        static_cast<uint32_t>(target.DestBlendAlpha), static_cast<uint32_t>(target.BlendOpAlpha),
                        static_cast<uint32_t>(target.LogicOp), target.RenderTargetWriteMask});
        const auto& depth = state.depth;
        key.insert(key.end(), {static_cast<uint32_t>(depth.DepthEnable), static_cast<uint32_t>(depth.DepthWriteMask),
                               static_cast<uint32_t>(depth.DepthFunc), static_cast<uint32_t>(depth.StencilEnable),
                               depth.StencilReadMask, depth.StencilWriteMask});
        Face(key, depth.FrontFace);
        Face(key, depth.BackFace);
        const auto& raster = state.rasterizer;
        key.insert(key.end(),
                   {static_cast<uint32_t>(raster.FillMode), static_cast<uint32_t>(raster.CullMode),
                    static_cast<uint32_t>(raster.FrontCounterClockwise), static_cast<uint32_t>(raster.DepthBias),
                    FloatBits(raster.DepthBiasClamp), FloatBits(raster.SlopeScaledDepthBias),
                    static_cast<uint32_t>(raster.DepthClipEnable), static_cast<uint32_t>(raster.MultisampleEnable),
                    static_cast<uint32_t>(raster.AntialiasedLineEnable), raster.ForcedSampleCount,
                    static_cast<uint32_t>(raster.ConservativeRaster), state.sampleMask,
                    static_cast<uint32_t>(ConvertTopology(topology)), targets.colorCount,
                    static_cast<uint32_t>(targets.depth), targets.samples.Count, targets.samples.Quality});
        for (uint32_t i = 0; i < targets.colorCount; ++i)
            key.push_back(static_cast<uint32_t>(targets.colors[i]));
        key.push_back(static_cast<uint32_t>(input.strides.size()));
        key.insert(key.end(), input.strides.begin(), input.strides.end());
        key.push_back(static_cast<uint32_t>(input.elements.size()));
        for (const auto& element : input.elements)
        {
            Text(key, element.SemanticName);
            key.insert(key.end(), {element.SemanticIndex, static_cast<uint32_t>(element.Format), element.InputSlot,
                                   element.AlignedByteOffset, static_cast<uint32_t>(element.InputSlotClass),
                                   element.InstanceDataStepRate});
        }
    }
    void FillPipelineKey(const std::string& shaderKey, const PipelineState& state, const InputLayout& input,
                         const PipelineTargets& targets, SourcePrimitiveType topology, PipelineKey& result)
    {
        FillStateKey(state, input, targets, topology, result);
        result.usesShaderIdentity = false;
        result.shaderIdentity = 0;
        result.shader = shaderKey;
    }
    void FillPipelineKey(uint64_t shaderIdentity, const PipelineState& state, const InputLayout& input,
                         const PipelineTargets& targets, SourcePrimitiveType topology, PipelineKey& result)
    {
        FillStateKey(state, input, targets, topology, result);
        result.usesShaderIdentity = true;
        result.shaderIdentity = shaderIdentity;
        result.shader.clear();
    }
    PipelineKey MakePipelineKey(const std::string& shaderKey, const PipelineState& state, const InputLayout& input,
                                const PipelineTargets& targets, SourcePrimitiveType topology)
    {
        PipelineKey result;
        FillPipelineKey(shaderKey, state, input, targets, topology, result);
        return result;
    }
    PipelineKey MakePipelineKey(uint64_t shaderIdentity, const PipelineState& state, const InputLayout& input,
                                const PipelineTargets& targets, SourcePrimitiveType topology)
    {
        PipelineKey result;
        FillPipelineKey(shaderIdentity, state, input, targets, topology, result);
        return result;
    }
    size_t PipelineKeyHash::operator()(const PipelineKey& key) const noexcept
    {
        size_t hash =
            key.usesShaderIdentity ? std::hash<uint64_t>{}(key.shaderIdentity) : std::hash<std::string>{}(key.shader);
        hash ^= static_cast<size_t>(key.usesShaderIdentity) + size_t{0x9e3779b9} + (hash << 6) + (hash >> 2);
        for (auto value : key.fields)
            hash ^= std::hash<uint32_t>{}(value) + size_t{0x9e3779b9} + (hash << 6) + (hash >> 2);
        return hash;
    }
} // namespace Celeste::Graphics::Direct3D12
