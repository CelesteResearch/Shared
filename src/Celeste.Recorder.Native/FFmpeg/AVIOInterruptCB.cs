namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    public struct AVIOInterruptCB
    {
        public AVIOInterruptCB_callback_func callback;

        public unsafe void* opaque;
    }
}
