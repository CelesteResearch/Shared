namespace FFmpeg
{
    public struct ID3D11VideoContextVtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* GetDevice;

        public unsafe void* GetPrivateData;

        public unsafe void* SetPrivateData;

        public unsafe void* SetPrivateDataInterface;

        public unsafe void* GetDecoderBuffer;

        public unsafe void* ReleaseDecoderBuffer;

        public unsafe void* DecoderBeginFrame;

        public unsafe void* DecoderEndFrame;

        public unsafe void* SubmitDecoderBuffers;

        public unsafe void* DecoderExtension;

        public unsafe void* VideoProcessorSetOutputTargetRect;

        public unsafe void* VideoProcessorSetOutputBackgroundColor;

        public unsafe void* VideoProcessorSetOutputColorSpace;

        public unsafe void* VideoProcessorSetOutputAlphaFillMode;

        public unsafe void* VideoProcessorSetOutputConstriction;

        public unsafe void* VideoProcessorSetOutputStereoMode;

        public unsafe void* VideoProcessorSetOutputExtension;

        public unsafe void* VideoProcessorGetOutputTargetRect;

        public unsafe void* VideoProcessorGetOutputBackgroundColor;

        public unsafe void* VideoProcessorGetOutputColorSpace;

        public unsafe void* VideoProcessorGetOutputAlphaFillMode;

        public unsafe void* VideoProcessorGetOutputConstriction;

        public unsafe void* VideoProcessorGetOutputStereoMode;

        public unsafe void* VideoProcessorGetOutputExtension;

        public unsafe void* VideoProcessorSetStreamFrameFormat;

        public unsafe void* VideoProcessorSetStreamColorSpace;

        public unsafe void* VideoProcessorSetStreamOutputRate;

        public unsafe void* VideoProcessorSetStreamSourceRect;

        public unsafe void* VideoProcessorSetStreamDestRect;

        public unsafe void* VideoProcessorSetStreamAlpha;

        public unsafe void* VideoProcessorSetStreamPalette;

        public unsafe void* VideoProcessorSetStreamPixelAspectRatio;

        public unsafe void* VideoProcessorSetStreamLumaKey;

        public unsafe void* VideoProcessorSetStreamStereoFormat;

        public unsafe void* VideoProcessorSetStreamAutoProcessingMode;

        public unsafe void* VideoProcessorSetStreamFilter;

        public unsafe void* VideoProcessorSetStreamExtension;

        public unsafe void* VideoProcessorGetStreamFrameFormat;

        public unsafe void* VideoProcessorGetStreamColorSpace;

        public unsafe void* VideoProcessorGetStreamOutputRate;

        public unsafe void* VideoProcessorGetStreamSourceRect;

        public unsafe void* VideoProcessorGetStreamDestRect;

        public unsafe void* VideoProcessorGetStreamAlpha;

        public unsafe void* VideoProcessorGetStreamPalette;

        public unsafe void* VideoProcessorGetStreamPixelAspectRatio;

        public unsafe void* VideoProcessorGetStreamLumaKey;

        public unsafe void* VideoProcessorGetStreamStereoFormat;

        public unsafe void* VideoProcessorGetStreamAutoProcessingMode;

        public unsafe void* VideoProcessorGetStreamFilter;

        public unsafe void* VideoProcessorGetStreamExtension;

        public unsafe void* VideoProcessorBlt;

        public unsafe void* NegotiateCryptoSessionKeyExchange;

        public unsafe void* EncryptionBlt;

        public unsafe void* DecryptionBlt;

        public unsafe void* StartSessionKeyRefresh;

        public unsafe void* FinishSessionKeyRefresh;

        public unsafe void* GetEncryptionBltKey;

        public unsafe void* NegotiateAuthenticatedChannelKeyExchange;

        public unsafe void* QueryAuthenticatedChannel;

        public unsafe void* ConfigureAuthenticatedChannel;

        public unsafe void* VideoProcessorSetStreamRotation;

        public unsafe void* VideoProcessorGetStreamRotation;
    }
}
