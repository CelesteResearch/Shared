namespace FFmpeg
{
    public struct AVDeviceInfo
    {
        public unsafe byte* device_name;

        public unsafe byte* device_description;

        public unsafe AVMediaType* media_types;

        public int nb_media_types;
    }
}
