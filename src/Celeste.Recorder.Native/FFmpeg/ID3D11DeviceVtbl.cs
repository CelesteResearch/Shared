namespace FFmpeg
{
    public struct ID3D11DeviceVtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* CreateBuffer;

        public unsafe void* CreateTexture1D;

        public unsafe void* CreateTexture2D;

        public unsafe void* CreateTexture3D;

        public unsafe void* CreateShaderResourceView;

        public unsafe void* CreateUnorderedAccessView;

        public unsafe void* CreateRenderTargetView;

        public unsafe void* CreateDepthStencilView;

        public unsafe void* CreateInputLayout;

        public unsafe void* CreateVertexShader;

        public unsafe void* CreateGeometryShader;

        public unsafe void* CreateGeometryShaderWithStreamOutput;

        public unsafe void* CreatePixelShader;

        public unsafe void* CreateHullShader;

        public unsafe void* CreateDomainShader;

        public unsafe void* CreateComputeShader;

        public unsafe void* CreateClassLinkage;

        public unsafe void* CreateBlendState;

        public unsafe void* CreateDepthStencilState;

        public unsafe void* CreateRasterizerState;

        public unsafe void* CreateSamplerState;

        public unsafe void* CreateQuery;

        public unsafe void* CreatePredicate;

        public unsafe void* CreateCounter;

        public unsafe void* CreateDeferredContext;

        public unsafe void* OpenSharedResource;

        public unsafe void* CheckFormatSupport;

        public unsafe void* CheckMultisampleQualityLevels;

        public unsafe void* CheckCounterInfo;

        public unsafe void* CheckCounter;

        public unsafe void* CheckFeatureSupport;

        public unsafe void* GetPrivateData;

        public unsafe void* SetPrivateData;

        public unsafe void* SetPrivateDataInterface;

        public unsafe void* GetFeatureLevel;

        public unsafe void* GetCreationFlags;

        public unsafe void* GetDeviceRemovedReason;

        public unsafe void* GetImmediateContext;

        public unsafe void* SetExceptionMode;

        public unsafe void* GetExceptionMode;
    }
}
