namespace FFmpeg
{
    public struct ID3D11VideoDeviceVtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* CreateVideoDecoder;

        public unsafe void* CreateVideoProcessor;

        public unsafe void* CreateAuthenticatedChannel;

        public unsafe void* CreateCryptoSession;

        public unsafe void* CreateVideoDecoderOutputView;

        public unsafe void* CreateVideoProcessorInputView;

        public unsafe void* CreateVideoProcessorOutputView;

        public unsafe void* CreateVideoProcessorEnumerator;

        public unsafe void* GetVideoDecoderProfileCount;

        public unsafe void* GetVideoDecoderProfile;

        public unsafe void* CheckVideoDecoderFormat;

        public unsafe void* GetVideoDecoderConfigCount;

        public unsafe void* GetVideoDecoderConfig;

        public unsafe void* GetContentProtectionCaps;

        public unsafe void* CheckCryptoKeyExchange;

        public unsafe void* SetPrivateData;

        public unsafe void* SetPrivateDataInterface;
    }
}
