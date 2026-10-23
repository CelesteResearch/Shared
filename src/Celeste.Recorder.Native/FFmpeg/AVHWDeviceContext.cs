namespace FFmpeg
{
    public struct AVHWDeviceContext
    {
        public unsafe AVClass* av_class;

        public unsafe AVHWDeviceInternal* @internal;

        public AVHWDeviceType type;

        public unsafe void* hwctx;

        public AVHWDeviceContext_free_func free;

        public unsafe void* user_opaque;
    }
}
