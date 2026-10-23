namespace FFmpeg
{
    public struct ID3D11DeviceContextVtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* GetDevice;

        public unsafe void* GetPrivateData;

        public unsafe void* SetPrivateData;

        public unsafe void* SetPrivateDataInterface;

        public unsafe void* VSSetConstantBuffers;

        public unsafe void* PSSetShaderResources;

        public unsafe void* PSSetShader;

        public unsafe void* PSSetSamplers;

        public unsafe void* VSSetShader;

        public unsafe void* DrawIndexed;

        public unsafe void* Draw;

        public unsafe void* Map;

        public unsafe void* Unmap;

        public unsafe void* PSSetConstantBuffers;

        public unsafe void* IASetInputLayout;

        public unsafe void* IASetVertexBuffers;

        public unsafe void* IASetIndexBuffer;

        public unsafe void* DrawIndexedInstanced;

        public unsafe void* DrawInstanced;

        public unsafe void* GSSetConstantBuffers;

        public unsafe void* GSSetShader;

        public unsafe void* IASetPrimitiveTopology;

        public unsafe void* VSSetShaderResources;

        public unsafe void* VSSetSamplers;

        public unsafe void* Begin;

        public unsafe void* End;

        public unsafe void* GetData;

        public unsafe void* SetPredication;

        public unsafe void* GSSetShaderResources;

        public unsafe void* GSSetSamplers;

        public unsafe void* OMSetRenderTargets;

        public unsafe void* OMSetRenderTargetsAndUnorderedAccessViews;

        public unsafe void* OMSetBlendState;

        public unsafe void* OMSetDepthStencilState;

        public unsafe void* SOSetTargets;

        public unsafe void* DrawAuto;

        public unsafe void* DrawIndexedInstancedIndirect;

        public unsafe void* DrawInstancedIndirect;

        public unsafe void* Dispatch;

        public unsafe void* DispatchIndirect;

        public unsafe void* RSSetState;

        public unsafe void* RSSetViewports;

        public unsafe void* RSSetScissorRects;

        public unsafe void* CopySubresourceRegion;

        public unsafe void* CopyResource;

        public unsafe void* UpdateSubresource;

        public unsafe void* CopyStructureCount;

        public unsafe void* ClearRenderTargetView;

        public unsafe void* ClearUnorderedAccessViewUint;

        public unsafe void* ClearUnorderedAccessViewFloat;

        public unsafe void* ClearDepthStencilView;

        public unsafe void* GenerateMips;

        // ReSharper disable once InconsistentNaming
        public unsafe void* SetResourceMinLOD;

        // ReSharper disable once InconsistentNaming
        public unsafe void* GetResourceMinLOD;

        public unsafe void* ResolveSubresource;

        public unsafe void* ExecuteCommandList;

        public unsafe void* HSSetShaderResources;

        public unsafe void* HSSetShader;

        public unsafe void* HSSetSamplers;

        public unsafe void* HSSetConstantBuffers;

        public unsafe void* DSSetShaderResources;

        public unsafe void* DSSetShader;

        public unsafe void* DSSetSamplers;

        public unsafe void* DSSetConstantBuffers;

        public unsafe void* CSSetShaderResources;

        public unsafe void* CSSetUnorderedAccessViews;

        public unsafe void* CSSetShader;

        public unsafe void* CSSetSamplers;

        public unsafe void* CSSetConstantBuffers;

        public unsafe void* VSGetConstantBuffers;

        public unsafe void* PSGetShaderResources;

        public unsafe void* PSGetShader;

        public unsafe void* PSGetSamplers;

        public unsafe void* VSGetShader;

        public unsafe void* PSGetConstantBuffers;

        public unsafe void* IAGetInputLayout;

        public unsafe void* IAGetVertexBuffers;

        public unsafe void* IAGetIndexBuffer;

        public unsafe void* GSGetConstantBuffers;

        public unsafe void* GSGetShader;

        public unsafe void* IAGetPrimitiveTopology;

        public unsafe void* VSGetShaderResources;

        public unsafe void* VSGetSamplers;

        public unsafe void* GetPredication;

        public unsafe void* GSGetShaderResources;

        public unsafe void* GSGetSamplers;

        public unsafe void* OMGetRenderTargets;

        public unsafe void* OMGetRenderTargetsAndUnorderedAccessViews;

        public unsafe void* OMGetBlendState;

        public unsafe void* OMGetDepthStencilState;

        public unsafe void* SOGetTargets;

        public unsafe void* RSGetState;

        public unsafe void* RSGetViewports;

        public unsafe void* RSGetScissorRects;

        public unsafe void* HSGetShaderResources;

        public unsafe void* HSGetShader;

        public unsafe void* HSGetSamplers;

        public unsafe void* HSGetConstantBuffers;

        public unsafe void* DSGetShaderResources;

        public unsafe void* DSGetShader;

        public unsafe void* DSGetSamplers;

        public unsafe void* DSGetConstantBuffers;

        public unsafe void* CSGetShaderResources;

        public unsafe void* CSGetUnorderedAccessViews;

        public unsafe void* CSGetShader;

        public unsafe void* CSGetSamplers;

        public unsafe void* CSGetConstantBuffers;

        public unsafe void* ClearState;

        public unsafe void* Flush;

        public new unsafe void* GetType;

        public unsafe void* GetContextFlags;

        public unsafe void* FinishCommandList;
    }
}
