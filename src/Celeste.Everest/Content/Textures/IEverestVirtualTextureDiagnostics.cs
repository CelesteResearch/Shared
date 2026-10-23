namespace Celeste.Everest.Content.Textures
{
    public interface IEverestVirtualTextureDiagnostics
    {
        void InvalidPngMagic(ulong value, string path);
        void InvalidPngFirstChunkLength(uint value, string path);
        void InvalidPngHeaderMarker(uint value, string path);
    }
}
