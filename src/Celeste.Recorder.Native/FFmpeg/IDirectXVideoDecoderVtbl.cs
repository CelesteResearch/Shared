namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    public struct IDirectXVideoDecoderVtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* GetVideoDecoderService;

        public unsafe void* GetCreationParameters;

        public unsafe void* GetBuffer;

        public unsafe void* ReleaseBuffer;

        public unsafe void* BeginFrame;

        public unsafe void* EndFrame;

        public unsafe void* Execute;
    }
}
