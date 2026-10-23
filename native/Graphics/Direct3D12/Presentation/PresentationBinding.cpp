#include "PresentationBinding.h"
namespace Celeste::Graphics::Direct3D12
{
    PresentationDescriptors::PresentationDescriptors(const DeviceContext& context)
    {
        D3D12_DESCRIPTOR_HEAP_DESC heap{};
        heap.NumDescriptors = 1;
        heap.Type = D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV;
        heap.Flags = D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE;
        CheckResult(context.device->CreateDescriptorHeap(&heap, IID_PPV_ARGS(&shaderHeap)),
                    "Create presentation SRV heap");
        heap.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV;
        heap.Flags = D3D12_DESCRIPTOR_HEAP_FLAG_NONE;
        CheckResult(context.device->CreateDescriptorHeap(&heap, IID_PPV_ARGS(&renderHeap)),
                    "Create presentation RTV heap");
    }
    void PresentationBinding::Record(ID3D12GraphicsCommandList* commands) const noexcept
    {
        D3D12_RESOURCE_BARRIER barrier{};
        barrier.Type = D3D12_RESOURCE_BARRIER_TYPE_TRANSITION;
        barrier.Transition = {output.Get(), D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES, info.incomingState,
                              D3D12_RESOURCE_STATE_RENDER_TARGET};
        if (info.incomingState != D3D12_RESOURCE_STATE_RENDER_TARGET)
            commands->ResourceBarrier(1, &barrier);
        Draw(commands);
        barrier.Transition.StateBefore = D3D12_RESOURCE_STATE_RENDER_TARGET;
        barrier.Transition.StateAfter = info.outgoingState;
        if (info.outgoingState != D3D12_RESOURCE_STATE_RENDER_TARGET)
            commands->ResourceBarrier(1, &barrier);
    }
    void PresentationBinding::Draw(ID3D12GraphicsCommandList* commands) const noexcept
    {
        commands->SetGraphicsRootSignature(pipeline->root.Get());
        commands->SetPipelineState(pipeline->pipeline.Get());
        ID3D12DescriptorHeap* heaps[] = {descriptors->shaderHeap.Get()};
        commands->SetDescriptorHeaps(1, heaps);
        commands->SetGraphicsRoot32BitConstants(0, 4, uv, 0);
        commands->SetGraphicsRootDescriptorTable(1, descriptors->shaderHeap->GetGPUDescriptorHandleForHeapStart());
        commands->RSSetViewports(1, &viewport);
        commands->RSSetScissorRects(1, &scissor);
        const auto render = descriptors->renderHeap->GetCPUDescriptorHandleForHeapStart();
        commands->OMSetRenderTargets(1, &render, FALSE, nullptr);
        commands->IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
        commands->DrawInstanced(3, 1, 0, 0);
    }
}
