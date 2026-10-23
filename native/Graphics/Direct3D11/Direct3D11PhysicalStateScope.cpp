#include "Direct3D11PhysicalStateScope.h"
template <class T> static void Release(T* object)
{
    if (object)
        object->Release();
}
template <class T, size_t N> static void ReleaseAll(T* (&objects)[N])
{
    for (auto object : objects)
        Release(object);
}

Direct3D11PhysicalStateScope::Direct3D11PhysicalStateScope(ID3D11DeviceContext* physicalContext)
    : context(physicalContext)
{
    context->OMGetRenderTargets(8, targets, &depthView);
    context->OMGetBlendState(&blend, factor, &mask);
    context->OMGetDepthStencilState(&depth, &stencil);
    context->RSGetState(&rasterizer);
    context->RSGetViewports(&viewportCount, viewports);
    context->RSGetScissorRects(&scissorCount, scissors);
    context->IAGetInputLayout(&layout);
    context->IAGetVertexBuffers(0, 32, vertexBuffers, strides, offsets);
    context->IAGetIndexBuffer(&indexBuffer, &indexFormat, &indexOffset);
    context->IAGetPrimitiveTopology(&topology);
    context->VSGetShader(&vertexShader, vertexClasses, &vertexClassCount);
    context->PSGetShader(&pixelShader, pixelClasses, &pixelClassCount);
    context->VSGetConstantBuffers(0, 14, vertexConstants);
    context->PSGetConstantBuffers(0, 14, pixelConstants);
    context->VSGetSamplers(0, 16, vertexSamplers);
    context->PSGetSamplers(0, 16, pixelSamplers);
    context->VSGetShaderResources(0, 128, vertexTextures);
    context->PSGetShaderResources(0, 128, pixelTextures);
}

void Direct3D11PhysicalStateScope::Restore() const
{
    // Unbind source SRVs before restoring the host's RTVs to avoid hazards.
    ID3D11ShaderResourceView* nullResources[128] = {};
    context->VSSetShaderResources(0, 128, nullResources);
    context->PSSetShaderResources(0, 128, nullResources);
    context->OMSetRenderTargets(8, targets, depthView);
    context->OMSetBlendState(blend, factor, mask);
    context->OMSetDepthStencilState(depth, stencil);
    context->RSSetState(rasterizer);
    context->RSSetViewports(viewportCount, viewports);
    context->RSSetScissorRects(scissorCount, scissors);
    context->IASetInputLayout(layout);
    context->IASetVertexBuffers(0, 32, vertexBuffers, strides, offsets);
    context->IASetIndexBuffer(indexBuffer, indexFormat, indexOffset);
    context->IASetPrimitiveTopology(topology);
    context->VSSetShader(vertexShader, vertexClasses, vertexClassCount);
    context->PSSetShader(pixelShader, pixelClasses, pixelClassCount);
    context->VSSetConstantBuffers(0, 14, vertexConstants);
    context->PSSetConstantBuffers(0, 14, pixelConstants);
    context->VSSetSamplers(0, 16, vertexSamplers);
    context->PSSetSamplers(0, 16, pixelSamplers);
    context->VSSetShaderResources(0, 128, vertexTextures);
    context->PSSetShaderResources(0, 128, pixelTextures);
}

Direct3D11PhysicalStateScope::~Direct3D11PhysicalStateScope()
{
    ReleaseAll(targets);
    Release(depthView);
    Release(blend);
    Release(depth);
    Release(rasterizer);
    Release(layout);
    ReleaseAll(vertexBuffers);
    Release(indexBuffer);
    Release(vertexShader);
    Release(pixelShader);
    ReleaseAll(vertexClasses);
    ReleaseAll(pixelClasses);
    ReleaseAll(vertexConstants);
    ReleaseAll(pixelConstants);
    ReleaseAll(vertexSamplers);
    ReleaseAll(pixelSamplers);
    ReleaseAll(vertexTextures);
    ReleaseAll(pixelTextures);
}
