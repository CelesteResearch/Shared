namespace FFmpeg
{
    public struct IDirect3DDeviceManager9Vtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* ResetDevice;

        public unsafe void* OpenDeviceHandle;

        public unsafe void* CloseDeviceHandle;

        public unsafe void* TestDevice;

        public unsafe void* LockDevice;

        public unsafe void* UnlockDevice;

        public unsafe void* GetVideoService;
    }
}
