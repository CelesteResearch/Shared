#pragma once
#include <d3d11.h>

// GPU-only borrowed-device pipeline isolation. The shared source device keeps its own
// source state fields; this captures/restores only the host's physical context.
class Direct3D11PhysicalStateScope
{
    ID3D11DeviceContext* context;
    ID3D11RenderTargetView* targets[8] = {};
    ID3D11DepthStencilView* depthView = nullptr;
    ID3D11BlendState* blend = nullptr;
    float factor[4] = {};
    UINT mask = 0;
    ID3D11DepthStencilState* depth = nullptr;
    UINT stencil = 0;
    ID3D11RasterizerState* rasterizer = nullptr;
    D3D11_VIEWPORT viewports[16] = {};
    UINT viewportCount = 16;
    D3D11_RECT scissors[16] = {};
    UINT scissorCount = 16;
    ID3D11InputLayout* layout = nullptr;
    ID3D11Buffer* vertexBuffers[32] = {};
    UINT strides[32] = {};
    UINT offsets[32] = {};
    ID3D11Buffer* indexBuffer = nullptr;
    DXGI_FORMAT indexFormat = DXGI_FORMAT_UNKNOWN;
    UINT indexOffset = 0;
    D3D11_PRIMITIVE_TOPOLOGY topology = D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED;
    ID3D11VertexShader* vertexShader = nullptr;
    ID3D11PixelShader* pixelShader = nullptr;
    ID3D11ClassInstance* vertexClasses[256] = {};
    UINT vertexClassCount = 256;
    ID3D11ClassInstance* pixelClasses[256] = {};
    UINT pixelClassCount = 256;
    ID3D11Buffer* vertexConstants[14] = {};
    ID3D11Buffer* pixelConstants[14] = {};
    ID3D11SamplerState* vertexSamplers[16] = {};
    ID3D11SamplerState* pixelSamplers[16] = {};
    ID3D11ShaderResourceView* vertexTextures[128] = {};
    ID3D11ShaderResourceView* pixelTextures[128] = {};

  public:
    explicit Direct3D11PhysicalStateScope(ID3D11DeviceContext* physicalContext);
    void Restore() const;
    ~Direct3D11PhysicalStateScope();
    Direct3D11PhysicalStateScope(const Direct3D11PhysicalStateScope&) = delete;
    Direct3D11PhysicalStateScope& operator=(const Direct3D11PhysicalStateScope&) = delete;
};
