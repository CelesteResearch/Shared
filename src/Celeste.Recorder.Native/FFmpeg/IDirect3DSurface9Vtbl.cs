namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    public struct IDirect3DSurface9Vtbl
    {
        public unsafe void* QueryInterface;

        public unsafe void* AddRef;

        public unsafe void* Release;

        public unsafe void* GetDevice;

        public unsafe void* SetPrivateData;

        public unsafe void* GetPrivateData;

        public unsafe void* FreePrivateData;

        public unsafe void* SetPriority;

        public unsafe void* GetPriority;

        public unsafe void* PreLoad;

        public new unsafe void* GetType;

        public unsafe void* GetContainer;

        public unsafe void* GetDesc;

        public unsafe void* LockRect;

        public unsafe void* UnlockRect;

        // ReSharper disable once InconsistentNaming
        public unsafe void* GetDC;

        // ReSharper disable once InconsistentNaming
        public unsafe void* ReleaseDC;
    }
}
