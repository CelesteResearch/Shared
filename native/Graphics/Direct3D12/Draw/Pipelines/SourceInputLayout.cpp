#include "SourcePipelineState.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    DXGI_FORMAT ConvertVertexFormat(SourceVertexElementFormat value)
    {
        static constexpr DXGI_FORMAT formats[] = {
            DXGI_FORMAT_R32_FLOAT,          DXGI_FORMAT_R32G32_FLOAT,      DXGI_FORMAT_R32G32B32_FLOAT,
            DXGI_FORMAT_R32G32B32A32_FLOAT, DXGI_FORMAT_R8G8B8A8_UNORM,    DXGI_FORMAT_R8G8B8A8_UINT,
            DXGI_FORMAT_R16G16_SINT,        DXGI_FORMAT_R16G16B16A16_SINT, DXGI_FORMAT_R16G16_SNORM,
            DXGI_FORMAT_R16G16B16A16_SNORM, DXGI_FORMAT_R16G16_FLOAT,      DXGI_FORMAT_R16G16B16A16_FLOAT};
        if (value < 0 || value >= 12)
            throw std::invalid_argument("Invalid source vertex format");
        return formats[value];
    }
    InputLayout ConvertInputLayout(const SourceNativeVertexBufferBinding* bindings, int32_t count)
    {
        if (count < 0 || (count && !bindings))
            throw std::invalid_argument("Invalid vertex bindings");
        static constexpr const char* semantics[] = {"POSITION", "COLOR",          "TEXCOORD",    "NORMAL",   "BINORMAL",
                                                    "TANGENT",  "BLENDINDICES",   "BLENDWEIGHT", "SV_DEPTH", "FOG",
                                                    "PSIZE",    "SV_SampleIndex", "TESSFACTOR"};
        bool used[13][16]{};
        InputLayout layout;
        layout.strides.reserve(static_cast<size_t>(count));
        for (int32_t slot = 0; slot < count; ++slot)
        {
            const auto& binding = bindings[slot];
            const auto& declaration = binding.vertexDeclaration;
            if (declaration.elementCount < 0 || declaration.vertexStride < 0 ||
                (declaration.elementCount && !declaration.elements))
                throw std::invalid_argument("Invalid source vertex declaration");
            layout.strides.push_back(static_cast<uint32_t>(declaration.vertexStride));
            for (int32_t i = 0; i < declaration.elementCount; ++i)
            {
                const auto& element = declaration.elements[i];
                if (element.vertexElementUsage < 0 || element.vertexElementUsage >= 13 || element.usageIndex < 0 ||
                    element.usageIndex >= 16 || element.offset < 0)
                    throw std::invalid_argument("Invalid vertex semantic or offset");
                D3D12_INPUT_ELEMENT_DESC output{};
                output.SemanticName = semantics[element.vertexElementUsage];
                UINT semanticIndex = static_cast<UINT>(element.usageIndex);
                auto& indices = used[element.vertexElementUsage];
                if (indices[semanticIndex])
                {
                    semanticIndex = 0;
                    while (semanticIndex < 16 && indices[semanticIndex])
                        ++semanticIndex;
                    if (semanticIndex == 16)
                        throw std::invalid_argument("Source vertex semantic slots exhausted");
                }
                indices[semanticIndex] = true;
                output.SemanticIndex = semanticIndex;
                output.Format = ConvertVertexFormat(element.vertexElementFormat);
                output.InputSlot = static_cast<UINT>(slot);
                output.AlignedByteOffset = static_cast<UINT>(element.offset);
                output.InputSlotClass = binding.instanceFrequency > 0 ? D3D12_INPUT_CLASSIFICATION_PER_INSTANCE_DATA
                                                                      : D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA;
                output.InstanceDataStepRate =
                    binding.instanceFrequency > 0 ? static_cast<UINT>(binding.instanceFrequency) : 0;
                layout.elements.push_back(output);
            }
        }
        return layout;
    }
} // namespace Celeste::Graphics::Direct3D12
