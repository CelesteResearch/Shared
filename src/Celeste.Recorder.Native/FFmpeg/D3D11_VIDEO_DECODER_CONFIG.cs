namespace FFmpeg
{
    public struct D3D11_VIDEO_DECODER_CONFIG
    {
        public _GUID guidConfigBitstreamEncryption;

        public _GUID guidConfigMBcontrolEncryption;

        public _GUID guidConfigResidDiffEncryption;

        public uint ConfigBitstreamRaw;

        public uint ConfigMBcontrolRasterOrder;

        public uint ConfigResidDiffHost;

        public uint ConfigSpatialResid8;

        public uint ConfigResid8Subtraction;

        public uint ConfigSpatialHost8or9Clipping;

        public uint ConfigSpatialResidInterleaved;

        public uint ConfigIntraResidUnsigned;

        public uint ConfigResidDiffAccelerator;

        public uint ConfigHostInverseScan;

        public uint ConfigSpecificIDCT;

        public uint Config4GroupedCoefs;

        public ushort ConfigMinRenderTargetBuffCount;

        public ushort ConfigDecoderSpecific;
    }
}
