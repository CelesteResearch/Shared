namespace FFmpeg
{
    public struct AVHWFramesContext
    {
        public unsafe AVClass* av_class;

        public unsafe AVHWFramesInternal* @internal;

        public unsafe AVBufferRef* device_ref;

        public unsafe AVHWDeviceContext* device_ctx;

        public unsafe void* hwctx;

        public AVHWFramesContext_free_func free;

        public unsafe void* user_opaque;

        public unsafe AVBufferPool* pool;

        public int initial_pool_size;

        public AVPixelFormat format;

        public AVPixelFormat sw_format;

        public int width;

        public int height;
    }
}
