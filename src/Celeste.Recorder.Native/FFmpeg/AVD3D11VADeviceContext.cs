namespace FFmpeg
{
    public struct AVD3D11VADeviceContext
    {
        public unsafe ID3D11Device* device;

        public unsafe ID3D11DeviceContext* device_context;

        public unsafe ID3D11VideoDevice* video_device;

        public unsafe ID3D11VideoContext* video_context;

        public AVD3D11VADeviceContext_lock_func @lock;

        public AVD3D11VADeviceContext_unlock_func unlock;

        public unsafe void* lock_ctx;
    }
}
